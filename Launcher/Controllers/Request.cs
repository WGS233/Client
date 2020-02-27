using System;
using System.IO;
using System.IO.Compression;
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
            WebRequest request = WebRequest.Create(new Uri(Globals.LauncherConfig.BackendUrl + url));
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
				using (MemoryStream input = new MemoryStream())
				{
					using (MemoryStream ms = new MemoryStream())
					{
						using (DeflateStream zip = new DeflateStream(input, CompressionMode.Decompress))
						{
							responseStream.CopyTo(input);
							zip.CopyTo(ms);
							return Encoding.UTF8.GetString(ms.ToArray());
						}
					}
				}
			}
        }
    }
}
