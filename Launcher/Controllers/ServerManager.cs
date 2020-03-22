using System.Collections.Generic;

namespace Launcher
{
	public class ServerManager
	{
		public List<ServerInfo> AvailableServers { get; private set; }
		public ServerInfo SelectedServer { get; private set; }

		public ServerManager()
		{
			SelectedServer = null;
			AvailableServers = new List<ServerInfo>();
		}

		public static ResponseData<ServerInfo> RequestConnect()
		{
			string json = request.Send("/launcher/server/connect", "");
			return Json.Deserialize<ResponseData<ServerInfo>>(json);
		}

		public void SelectServer(int index)
		{
			if (index < 0 || index >= AvailableServers.Count)
			{
				SelectedServer = null;
				return;
			}

			SelectedServer = AvailableServers[index];
		}

		public void LoadServer(string backendUrl)
		{
			RequestHandler.ChangeBackendUrl(backendUrl);
			ResponseData<ServerInfo> responseData = RequestHandler.GetDataResponse<ServerInfo>(RequestHandler.Request<ServerInfo>("/launcher/server/connect"));

			try
			{
				
				responseData = ();

				if (responseData == null)
				{
					return;
				}
			}
			catch
			{
				return;
			}

			AvailableServers.Add(responseData.data);
		}

		public void LoadServers(string[] servers)
		{
			AvailableServers.Clear();

			foreach (string backendUrl in servers)
			{
				LoadServer(backendUrl);
			}
		}
	}
}
