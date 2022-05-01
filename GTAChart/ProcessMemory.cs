using System;
using System.Diagnostics;
using System.Windows;

namespace GTAChart
{
	public class ProcessMemory
	{
		private IntPtr Handle { get; set; }
		private Process Process { get; set; }

		public ProcessMemory(int pId, ProcessAccessRights accessRights)
		{
			if (pId < 1) throw new ArgumentNullException(nameof(pId));
			OpenProcess(pId, accessRights);
		}

		public ProcessMemory(int pId) : this(pId, ProcessAccessRights.All)
		{
		}

		public ProcessMemory(string processName, ProcessAccessRights accessRights)
		{
			Process[] processes = Process.GetProcessesByName(processName);
			if (processes.Length == 0)
				throw new ArgumentException("No process found with name " + processName);
			Process = processes[0];
			OpenProcess(Process.Id, accessRights);
		}

		public ProcessMemory(string processName) : this(processName, ProcessAccessRights.All)
		{
		}

		~ProcessMemory()
		{
			CloseHandle();
		}

		public void OpenProcess(int pId, ProcessAccessRights access)
		{
			CloseHandle();
			Handle = Memory.OpenProcess(access.Value, false, (uint) pId);
			if (Handle == IntPtr.Zero)
				throw new AccessViolationException("No permission to access the process with ID " + pId +
				                                   " and access rights " + access.Value + ".");
		}

		public void CloseHandle()
		{
			if (Handle != IntPtr.Zero)
				Memory.CloseHandle(Handle);
		}

		public bool Write<T>(IntPtr address, T data) where T : struct
		{
			return Memory.Write(Handle, address, data);
		}

		public T Read<T>(IntPtr address) where T : struct
		{
			return Memory.Read<T>(Handle, address);
		}
	}
}
