using System.Collections.Generic;

namespace Launcher
{
	public class ServerManager
	{
		private List<Server> availableServers;

		public ServerManager(string[] servers)
		{
			availableServers = new List<Server>();
			LoadServers(servers);
		}

		public Server GetServer(int index)
		{
			if (availableServers.Count == 0)
			{
				// create local server
				availableServers.Add(new Server());
			}

			if (index < 0 || index > availableServers.Count)
			{
				// value out of range
				return availableServers[0];
			}

			return availableServers[index];
		}

		public bool LoadServer(string backendUrl)
		{
			// ping server
			string output = "";

			try
			{
				RequestHandler.ChangeBackendUrl(backendUrl);
				output = RequestHandler.RequestConnect();
			}
			catch
			{
				// connection to remote end point failed
				return false;
			}
			
			if (output == "" || output == null)
			{
				// data is corrupted
				return false;
			}

			// add server
			availableServers.Add(Json.Deserialize<Server>(output));
			return true;
		}

		public void LoadServers(string[] servers)
		{
			foreach (string backendUrl in servers)
			{
				LoadServer(backendUrl);
			}
		}
	}
}
