namespace GTAChart
{
	public class GTAProcess : ProcessMemory
	{
		public GTAProcess() : base("GTA5", ProcessAccessRights.All)
		{
		}

		public float CurrentSpeed => Read<float>(BaseAddress + 0x254A754);
	}
}
