using System;
using System.Diagnostics;
using System.Text;

namespace Launcher
{
    public class GameStarter
    {
		public int LaunchGame(Server server)
        {
			LoginRequestData loginData = new LoginRequestData(Globals.LauncherConfig.Email, Globals.LauncherConfig.Password);
			string accountId = "";

			// get profile ID
			try
			{
				accountId = RequestHandler.RequestLogin(loginData);

				if (accountId == "0")
				{
					// account is not found
					return -1;
				}
			}
            catch
            {
				// cannot connect to remote end point
                return -2;
            }
			
            if (!System.IO.File.Exists(Globals.ClientExecutable))
            {
				// executable to start is not found
                return -3;
            }

            // set backend url
            Globals.ClientConfig.BackendUrl = server.backendUrl;
            Json.Save<ClientConfig>(Globals.ClientConfigFile, Globals.ClientConfig);

			// start game
			ProcessStartInfo clientProcess = new ProcessStartInfo(Globals.ClientExecutable);
            clientProcess.Arguments = "-bC5vLmcuaS5u=" + GenerateToken(loginData) + " -token=" + accountId + " -screenmode=fullscreen -window-mode=borderless";
            clientProcess.UseShellExecute = false;
            clientProcess.WorkingDirectory = Environment.CurrentDirectory;

            Process.Start(clientProcess);
			return 1;
        }

        private string GenerateToken(LoginRequestData data)
        {
            // generate stringified token
            LoginToken token = new LoginToken(data.email, data.password);
            string serialized = Json.Serialize(token);
            string result = Convert.ToBase64String(Encoding.UTF8.GetBytes(serialized));

            // add closing signature to the token
            return result + "=";
        }
    }
}
