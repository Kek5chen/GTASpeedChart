using System;
using System.Diagnostics;

namespace GTAChart
{
	public class ProcessMemory
	{
		private IntPtr Handle { get; set; }

		public ProcessMemory(int pId, ProcessAccessRights accessRights)
		{
			if(pId < 1) throw new ArgumentException("pId must be greater than 0");
			OpenProcess(pId, accessRights);
		}

		public ProcessMemory(int pId) : this(pId, ProcessAccessRights.All)
		{
		}
		
		public ProcessMemory(string processName, ProcessAccessRights accessRights)
		{
			Process[] process = Process.GetProcessesByName(processName);
			if(process.Length == 0)
				throw new ArgumentException("No process found with name " + processName);
			OpenProcess(process[0].Id, accessRights);
		}
		
		public ProcessMemory(string processName) : this(processName, ProcessAccessRights.All)
		{
		}

		public void OpenProcess(int pId, ProcessAccessRights access)
		{
			Handle = Memory.OpenProcess(access.Value, false, pId);
			if (Handle == IntPtr.Zero)
				throw new AccessViolationException("No permission to access the process with ID " + pId + ".");
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
