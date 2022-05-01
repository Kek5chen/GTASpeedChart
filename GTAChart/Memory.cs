using System;
using System.Runtime.InteropServices;

namespace GTAChart
{
	public static class Memory
	{
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(ulong dwDesiredAccess, bool bInheritHandle, ulong dwProcessId);
		
		[DllImport("kernel32.dll")]
		public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesRead);
		
		[DllImport("kernel32.dll")]
		public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);
		
		public static T Read<T>(IntPtr handle, IntPtr address) where T : struct
		{
			byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];
			ReadProcessMemory(handle, address, buffer, (uint)buffer.Length, out _);
			GCHandle handle2 = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			T structure = (T)Marshal.PtrToStructure(handle2.AddrOfPinnedObject(), typeof(T));
			handle2.Free();
			return structure;
		}
		
		public static bool Write<T>(IntPtr handle, IntPtr address, T value) where T : struct
		{
			byte[] buffer = new byte[Marshal.SizeOf(typeof(T))];
			GCHandle handle2 = GCHandle.Alloc(value, GCHandleType.Pinned);
			Marshal.Copy(handle2.AddrOfPinnedObject(), buffer, 0, buffer.Length);
			handle2.Free();
			return WriteProcessMemory(handle, address, buffer, (uint)buffer.Length, out _);
		}
	}
}
