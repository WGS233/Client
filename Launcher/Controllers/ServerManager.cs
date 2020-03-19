using System.Collections.Generic;

namespace Launcher
{
	public class ServerManager
	{
		private List<Server> availableServers;

		public ServerManager()
		{
			availableServers = new List<Server>();
			LoadServers();
		}

		public Server GetServer(int index)
		{
			if (index < 0 || index > availableServers.Count)
			{
				return null;
			}

			return availableServers[index];
		}

		public bool LoadServer(int index)
		{
			Server server = new Server();

			// ping server
			Globals.LauncherConfig.Backend = index;
			string output = RequestHandler.RequestConnect();
			
			if (output == "FAILED" || output == "" || output == null)
			{
				// connection to remote end point failed
				return false;
			}

			// set server data
			server.BackendUrl = RequestHandler.GetBackendUrl();
			server.Name = output;

			// get server editions
			output = RequestHandler.RequestEditions();
			server.Editions = Json.Deserialize<string[]>(output);

			if (server.Editions == null || server.Editions.Length == 0)
			{
				return false;
			}

			availableServers.Add(server);
			return true;
		}

		public void LoadServers()
		{
			for (int i = 0; i < Globals.LauncherConfig.Servers.Length; i++)
			{
				LoadServer(i);
			}
		}
	}
}
