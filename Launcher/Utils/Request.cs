using ComponentAce.Compression.Libs.zlib;
using System;
using System.IO;
using System.Net;

namespace Launcher
{
	public class Request
	{
		public string RemoteEndPoint;

		public Request()
		{
			RemoteEndPoint = "https://127.0.0.1";
		}

		public string Send(string url, string data)
		{
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

			WebRequest request = WebRequest.Create(new Uri(RemoteEndPoint + url));

			if (data != null || data != "")
			{
				byte[] bytes = SimpleZlib.CompressToBytes(data, zlibConst.Z_BEST_COMPRESSION);

				request.Method = "POST";
				request.ContentType = "application/json";
				request.ContentLength = bytes.Length;

				using (Stream requestStream = request.GetRequestStream())
				{
					requestStream.Write(bytes, 0, bytes.Length);
				}
			}
			else
			{
				request.Method = "GET";
			}

			WebResponse response = request.GetResponse();

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
