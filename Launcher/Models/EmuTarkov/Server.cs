namespace Launcher
{
	public class Server
	{
		public string BackendUrl;
		public string Name;
		public string[] Editions;

		public Server()
		{
			BackendUrl = "https://127.0.0.1";
			Name = "Local EmuTarkov Server";
			Editions = new string[] { "std", "lb", "pte", "eod" };
		}
	}
}
