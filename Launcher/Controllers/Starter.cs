using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using ComponentAce.Compression.Libs.zlib;
using EmuLib.Utils.HTTP;

namespace Launcher
{
    public static class Starter
    {
        public static int StartGame()
        {
            // detect if executable is found
            if (!System.IO.File.Exists(Globals.ClientExecutable))
            {
                return -1;
            }

            // generate token
            string token = GenerateToken(Globals.LauncherConfig.Email, Globals.LauncherConfig.Password);

            // get profile ID
            string accountId = "0";

            try
            {
                new HttpUtils.Create(null, Globals.LauncherConfig.BackendUrl).Post("/launcher/profile/login", token, true, (data) => {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (ZOutputStream zip = new ZOutputStream(ms))
                        {
                            zip.CopyTo(ms);
                            accountId = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                        }
                    }
                });
            }
            catch
            {
                return -2;
            }

            // account is not found
            if (accountId == "0")
            {
                return -3;
            }

            // set backend url
            Globals.ClientConfig.BackendUrl = Globals.LauncherConfig.BackendUrl;
            Json.Save<ClientConfig>(Globals.ClientConfigFile, Globals.ClientConfig);

            // start game
            ProcessStartInfo clientProcess = new ProcessStartInfo(Globals.ClientExecutable);
            clientProcess.Arguments = "-bC5vLmcuaS5u=" + token + " -token=" + accountId + " -screenmode=fullscreen";
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
