using Comfort.Common;
using EFT;
using UnityEngine;
using SessionInterface = GInterface23;

namespace EmuLib.Utils.Reflection
{
    internal static class ClientAppUtils
    {
        public static ClientApplication GetClientApp()
        {
            ClientApplication clientApp = Singleton<ClientApplication>.Instance;
            if (clientApp != null) return clientApp;

            Debug.LogError("ClientAppUtils GetClientApp() method. clientApp is null");
            return null;
        }

<<<<<<< HEAD
        public static GInterface23 GetBackendSession()
        {
            GInterface23 session = GetClientApp()?.GetClientBackEndSession();
=======
        public static SessionInterface GetBackendSession()
        {
			SessionInterface session = GetClientApp()?.GetClientBackEndSession();
>>>>>>> upstream/development
            if (session != null) return session;

            Debug.LogError("ClientAppUtils GetBackendSession() method. BackEndSession is null");
            return null;
        }

        public static string GetSessionId()
        {
<<<<<<< HEAD
            GInterface23 backend = GetBackendSession();
=======
			SessionInterface backend = GetBackendSession();
>>>>>>> upstream/development
            return backend?.Profile == null ? "-1" : backend.GetPhpSessionId();
        }
    }
}