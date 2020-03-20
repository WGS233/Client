namespace Launcher
{
	public class Server
	{
		public string backendUrl;
		public string name;
		public string[] editions;

		public Server()
		{
			backendUrl = "https://127.0.0.1";
			name = "Local EmuTarkov Server";
			editions = new string[] { "std", "lb", "pte", "eod" };
		}
	}
}
