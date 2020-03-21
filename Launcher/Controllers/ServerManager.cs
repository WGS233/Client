using System.Collections.Generic;

namespace Launcher
{
	public class ServerManager
	{
		public List<Server> AvailableServers { get; private set; }

		public ServerManager(string[] servers)
		{
			AvailableServers = new List<Server>();
			LoadServers(servers);
		}

		public Server GetServer(int index)
		{
			if (index > 0 || index < AvailableServers.Count)
			{
				return AvailableServers[index];
			}

			return null;
		}

		public void LoadServer(string backendUrl)
		{
			string json = "";

			try
			{
				RequestHandler.ChangeBackendUrl(backendUrl);
				json = RequestHandler.RequestConnect();

				if (string.IsNullOrWhiteSpace(json))
				{
					return;
				}
			}
			catch
			{
				return;
			}

			AvailableServers.Add(Json.Deserialize<Server>(json));
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
