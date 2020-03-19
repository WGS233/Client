using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Launcher
{
    public static class GameStarter
    {
        public static int LaunchGame()
        {
            // generate token
            string token = GenerateToken(Globals.LauncherConfig.Email, Globals.LauncherConfig.Password);

            // get profile ID
            string accountId = "0";

            try
            {
                accountId = Request.Send("/launcher/profile/login", "{ \"token\": " + Json.Serialize(token) + " }");
            }
            catch
            {
				// cannot connect to remote end point
                return -1;
            }

            if (accountId == "0")
            {
				// account is not found
				return -2;
            }

            if (!System.IO.File.Exists(Globals.ClientExecutable))
            {
				// executable to start is not found
                return -3;
            }

            // set backend url
            Globals.ClientConfig.BackendUrl = Globals.LauncherConfig.BackendUrl;
            Json.Save<ClientConfig>(Globals.ClientConfigFile, Globals.ClientConfig);

            // start game
            ProcessStartInfo clientProcess = new ProcessStartInfo(Globals.ClientExecutable);
            clientProcess.Arguments = "-bC5vLmcuaS5u=" + token + " -token=" + accountId + " -screenmode=fullscreen -window-mode=borderless";
            clientProcess.UseShellExecute = false;
            clientProcess.WorkingDirectory = Environment.CurrentDirectory;

            Process.Start(clientProcess);
            return 1;
        }

        private static string GenerateToken(string email, string password)
        {
            // generate stringified token
            LoginToken token = new LoginToken(email, password);
            string serialized = Json.Serialize(token);
            string result = Convert.ToBase64String(Encoding.UTF8.GetBytes(serialized));

            // add closing signature to the token
            return result + "=";
        }
    }
}
