namespace GTAChart
{
	public class ProcessAccessRights
	{
		private const uint ProcessAllAccess = 0x001F0FFF;
		private const uint ProcessCreateProcess = 0x0080;
		private const uint ProcessCreateThread = 0x0002;
		private const uint ProcessDupHandle = 0x0040;
		private const uint ProcessQueryInformation = 0x0400;
		private const uint ProcessQueryLimitedInformation = 0x1000;
		private const uint ProcessSetInformation = 0x0200;
		private const uint ProcessSetQuota = 0x0100;
		private const uint ProcessSuspendResume = 0x0800;
		private const uint ProcessTerminate = 0x0001;
		private const uint ProcessVmOperation = 0x0008;
		private const uint ProcessVmRead = 0x0010;
		private const uint ProcessVmWrite = 0x0020;
		private const uint ProcessSynchronize = 0x00100000;

		public uint Value { get; }
		private ProcessAccessRights(uint value)
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
