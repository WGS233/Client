namespace Launcher
{
	public class ResponseData<T>
	{
		public int err;
		public string errmsg;
		public T data;

		public ResponseData(T data)
		{
			err = 0;
			errmsg = "";
			this.data = data;
		}
	}
}
