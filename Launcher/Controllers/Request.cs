using System;
using System.IO;
using System.Net;
using System.Text;
using ComponentAce.Compression.Libs.zlib;

namespace Launcher
{
    public static class Request
    {
        public static string Send(string url, string data)
        {
            // set https protocol
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            // create request  
            WebRequest request = WebRequest.Create(Globals.LauncherConfig.BackendUrl + url);
            byte[] bytes = SimpleZlib.CompressToBytes(data, 9);

            request.Method = "PUT";
            request.ContentType = "application/json";
            request.ContentLength = bytes.Length;

            // send request
            Stream dataStream = request.GetRequestStream();
 
            dataStream.Write(bytes, 0, bytes.Length); 
            dataStream.Close();

            // receive response
            WebResponse response = request.GetResponse();
            string result = "";

            // get response data
            using (MemoryStream ms = new MemoryStream())
            {
                using (ZOutputStream zip = new ZOutputStream(ms))
                {
                    Stream responseStream = response.GetResponseStream();

                    responseStream.CopyTo(zip);
                    zip.CopyTo(ms);
                    result = System.Text.Encoding.UTF8.GetString(ms.ToArray());
                }
            }

            response.Close();
            return result;
        }
    }
}
