using System;
using System.IO;
using System.Net;
using ComponentAce.Compression.Libs.zlib;

namespace Launcher
{
	public class Request
	{
		public string BackendUrl;

		public Request()
		{
			this.BackendUrl = "https://127.0.0.1/";
		}

        public string Send(string url, string data)
        {
            // set https protocol
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            // create request  
            WebRequest request = WebRequest.Create(new Uri(BackendUrl + url));
            byte[] bytes = SimpleZlib.CompressToBytes(data, zlibConst.Z_BEST_COMPRESSION);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = bytes.Length;

			// send request
			using (Stream requestStream = request.GetRequestStream())
			{
				requestStream.Write(bytes, 0, bytes.Length);
			}

            // receive response
            WebResponse response = request.GetResponse();

            // get response data
			using (Stream responseStream = response.GetResponseStream())
			{
                using (MemoryStream ms = new MemoryStream())
                {
                    responseStream.CopyTo(ms);
                    return SimpleZlib.Decompress(ms.ToArray(), null);
                }
            }
        }
    }
}
