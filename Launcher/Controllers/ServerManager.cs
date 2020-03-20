using System.Collections.Generic;

namespace Launcher
{
	public class ServerManager
	{
		public List<Server> availableServers { get; private set; }

		public ServerManager(string[] servers)
		{
			availableServers = new List<Server>();
			LoadServers(servers);
		}

		public Server GetServer(int index)
		{
			if (index < 0 || index > availableServers.Count)
			{
				return null;
			}

			return availableServers[index];
		}

		public bool LoadServer(string backendUrl)
		{
			string json = "";

			try
			{
				RequestHandler.ChangeBackendUrl(backendUrl);
				json = RequestHandler.RequestConnect();

				if (string.IsNullOrWhiteSpace(json))
				{
					return false;
				}
			}
			catch
			{
				return false;
			}

			availableServers.Add(Json.Deserialize<Server>(json));
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
