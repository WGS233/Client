using System;

namespace Launcher
{
	public class RequestHandler
	{
		public const string ConnectionError = "Connection to the server cannot be established";
		private static Request request = new Request();

		public static string GetBackendUrl()
		{
			return request.RemoteEndPoint;
		}

		public static void ChangeBackendUrl(string backendUrl)
		{
			request.RemoteEndPoint = backendUrl;
		}

		public static ResponseData<T> Request<T>(string url)
		{
			string json = request.Send(url, null);
			return Json.Deserialize<ResponseData<T>>(json);
		}

		public static ResponseData<T> Request<T>(string url, string data)
		{
			string json = request.Send(url, data);
			return Json.Deserialize<ResponseData<T>>(json);
		}

		public static ResponseData<T2> Request<T1, T2>(string url, T1 data)
		{
			string json = request.Send(url, Json.Serialize(data));
			return Json.Deserialize<ResponseData<T2>>(json);
		}

		public static string GetEmptyResponse<T>(Func<ResponseData<T>> requestHandler)
		{
			ResponseData<T> responseData = null;

			try
			{
				responseData = requestHandler();

				if (responseData == null)
				{
					return ConnectionError;
				}

				if (responseData.err > 0)
				{
					return responseData.errmsg;
				}
			}
			catch
			{
				return ConnectionError;
			}

			return "OK";
		}

		public static string GetEmptyResponse<T1, T2>(Func<T1, ResponseData<T2>> requestHandler, T1 requestData)
		{
			ResponseData<T2> responseData = null;

			try
			{
				responseData = requestHandler(requestData);

				if (responseData == null)
				{
					return ConnectionError;
				}

				if (responseData.err > 0)
				{
					return responseData.errmsg;
				}
			}
			catch
			{
				return ConnectionError;
			}

			return "OK";
		}

		public static ResponseData<T> GetDataResponse<T>(Func<ResponseData<T>> requestHandler)
		{
			ResponseData<T> responseData = null;

			try
			{
				responseData = requestHandler();

				if (responseData == null)
				{
					return null;
				}
			}
			catch
			{
				return null;
			}

			return responseData;
		}

		public static ResponseData<T2> GetDataResponse<T1, T2>(Func<T1, ResponseData<T2>> requestHandler, T1 requestData)
		{
			ResponseData<T2> responseData = null;

			try
			{
				responseData = requestHandler(requestData);

				if (responseData == null)
				{
					return null;
				}
			}
			catch
			{
				return null;
			}

			return responseData;
		}
		

		public static ResponseData<string> RequestLogin(LoginRequestData data)
		{
			string json = request.Send("/launcher/profile/login", Json.Serialize(data));
			return Json.Deserialize<ResponseData<string>>(json);
		}

		public static ResponseData<string> RequestRegister(RegisterRequestData data)
		{
			string json = request.Send("/launcher/profile/register", Json.Serialize(data));
			return Json.Deserialize<ResponseData<string>>(json);
		}

		public static ResponseData<string> RequestRemove(LoginRequestData data)
		{
			string json = request.Send("/launcher/profile/remove", Json.Serialize(data));
			return Json.Deserialize<ResponseData<string>>(json);
		}

		public static ResponseData<AccountInfo> RequestAccount(LoginRequestData data)
		{
			string json = request.Send("/launcher/profile/get", Json.Serialize(data));
			return Json.Deserialize<ResponseData<AccountInfo>>(json);
		}

		public static ResponseData<string> RequestChangeEmail(ChangeRequestData data)
		{
			string json = request.Send("/launcher/profile/change/email", Json.Serialize(data));
			return Json.Deserialize<ResponseData<string>>(json);
		}

		public static ResponseData<string> RequestChangePassword(ChangeRequestData data)
		{
			string json = request.Send("/launcher/profile/change/password", Json.Serialize(data));
			return Json.Deserialize<ResponseData<string>>(json);
		}

		public static ResponseData<string> RequestWipe(RegisterRequestData data)
		{
			string json = request.Send("/launcher/profile/change/wipe", Json.Serialize(data));
			return Json.Deserialize<ResponseData<string>>(json);
		}
	}
}
