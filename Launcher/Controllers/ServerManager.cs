using System.Collections.Generic;

namespace Launcher
{
	public class ServerManager
	{
		public List<ServerInfo> AvailableServers { get; private set; }
		public ServerInfo SelectedServer { get; private set; }

		public ServerManager(string[] servers)
		{
			SelectedServer = null;
			AvailableServers = new List<ServerInfo>();
			LoadServers(servers);
		}

		public void SelectServer(int index)
		{
			if (index >= 0 || index < AvailableServers.Count)
			{
				SelectedServer = AvailableServers[index];
				return;
			}

			SelectedServer = null;
		}

		public void LoadServer(string backendUrl)
		{
			string json = "";

			try
			{
				RequestHandler.ChangeBackendUrl(backendUrl);
				json = RequestHandler.RequestConnect();
			}
			catch
			{
				return;
			}

			AvailableServers.Add(Json.Deserialize<ServerInfo>(json));
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
