using System;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace Launcher
{
    public class GameStarter
    {
		private const string clientExecutable = "EscapeFromTarkov.exe";

		public int LaunchGame(Server server, LoginRequestData loginData)
        {
			string accountId = "";

			try
			{
				accountId = RequestHandler.RequestLogin(loginData);

				if (string.IsNullOrWhiteSpace(accountId))
					return 0;

				if (accountId == "0")
					return -1;
			}
            catch
            {
                return -2;
            }
			
            if (!File.Exists(clientExecutable))
            {
                return -3;
            }

			string filepath = Environment.CurrentDirectory;

			ClientConfig clientConfig = JsonHandler.LoadClientConfig();
			clientConfig.BackendUrl = server.backendUrl;
			JsonHandler.SaveClientConfig(clientConfig);

			ProcessStartInfo clientProcess = new ProcessStartInfo(clientExecutable);
            clientProcess.Arguments = "-bC5vLmcuaS5u=" + GenerateToken(loginData) + " -token=" + accountId + " -screenmode=fullscreen -window-mode=borderless";
            clientProcess.UseShellExecute = false;
			clientProcess.WorkingDirectory = filepath;
            Process.Start(clientProcess);

			return 1;
        }

        private string GenerateToken(LoginRequestData data)
        {
            LoginToken token = new LoginToken(data.email, data.password);
            string serialized = Json.Serialize(token);
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(serialized)) + "=";
        }
    }
}
