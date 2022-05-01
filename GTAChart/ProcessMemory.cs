using System;
using System.Diagnostics;

namespace GTAChart
{
	public class ProcessMemory
	{
		private IntPtr Handle { get; set; }

		public ProcessMemory(ulong pId, ProcessAccessRights accessRights)
		{
			OpenProcess(pId, accessRights);
		}

		public ProcessMemory(ulong pId) : this(pId, ProcessAccessRights.All)
		{
		}

		public void OpenProcess(ulong pId, ProcessAccessRights access)
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
