namespace GTAChart
{
	public class ProcessAccessRights
	{
		private const ulong ProcessAllAccess = 0x000F0000L | 0x00100000L | 0xFFFF;
		private const ulong ProcessCreateProcess = 0x0080;
		private const ulong ProcessCreateThread = 0x0002;
		private const ulong ProcessDupHandle = 0x0040;
		private const ulong ProcessQueryInformation = 0x0400;
		private const ulong ProcessQueryLimitedInformation = 0x1000;
		private const ulong ProcessSetInformation = 0x0200;
		private const ulong ProcessSetQuota = 0x0100;
		private const ulong ProcessSuspendResume = 0x0800;
		private const ulong ProcessTerminate = 0x0001;
		private const ulong ProcessVmOperation = 0x0008;
		private const ulong ProcessVmRead = 0x0010;
		private const ulong ProcessVmWrite = 0x0020;
		private const ulong ProcessSynchronize = 0x00100000L;

		public ulong Value { get; }
		private ProcessAccessRights(ulong value)
		{
			Value = value;
		}
		
		public static ProcessAccessRights All => new ProcessAccessRights(ProcessAllAccess);
		public static ProcessAccessRights CreateProcess => new ProcessAccessRights(ProcessCreateProcess);
		public static ProcessAccessRights CreateThread => new ProcessAccessRights(ProcessCreateThread);
		public static ProcessAccessRights DupHandle => new ProcessAccessRights(ProcessDupHandle);
		public static ProcessAccessRights QueryInformation => new ProcessAccessRights(ProcessQueryInformation);
		public static ProcessAccessRights QueryLimitedInformation => new ProcessAccessRights(ProcessQueryLimitedInformation);
		public static ProcessAccessRights SetInformation => new ProcessAccessRights(ProcessSetInformation);
		public static ProcessAccessRights SetQuota => new ProcessAccessRights(ProcessSetQuota);
		public static ProcessAccessRights SuspendResume => new ProcessAccessRights(ProcessSuspendResume);
		public static ProcessAccessRights Terminate => new ProcessAccessRights(ProcessTerminate);
		public static ProcessAccessRights VmOperation => new ProcessAccessRights(ProcessVmOperation);
		public static ProcessAccessRights VmRead => new ProcessAccessRights(ProcessVmRead);
		public static ProcessAccessRights VmWrite => new ProcessAccessRights(ProcessVmWrite);
		public static ProcessAccessRights Synchronize => new ProcessAccessRights(ProcessSynchronize);
	}
}
