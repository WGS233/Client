using System;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace Launcher
{
    public class GameStarter
    {
		private const string clientExecutable = "EscapeFromTarkov.exe";

		public int LaunchGame(ServerInfo server, AccountInfo account)
        {			
            if (!File.Exists(clientExecutable))
            {
                return -1;
            }

			ClientConfig clientConfig = JsonHandler.LoadClientConfig();
			clientConfig.BackendUrl = server.backendUrl;
			JsonHandler.SaveClientConfig(clientConfig);

			ProcessStartInfo clientProcess = new ProcessStartInfo(clientExecutable);
            clientProcess.Arguments = "-bC5vLmcuaS5u=" + GenerateToken(account) + " -token=" + account.id + " -screenmode=fullscreen -window-mode=borderless";
            clientProcess.UseShellExecute = false;
			clientProcess.WorkingDirectory = Environment.CurrentDirectory;
			Process.Start(clientProcess);

			return 1;
        }

        private string GenerateToken(AccountInfo data)
        {
            LoginToken token = new LoginToken(data.email, data.password);
            string serialized = Json.Serialize(token);
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(serialized)) + "=";
        }
    }
}
