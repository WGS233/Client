using UnityEngine;
using EmuLib;

namespace EFT.Trainer
{
	public class Loader
	{
		public static GameObject HookObject
		{
			get
			{
				var result = GameObject.Find("Application (Main Client)");

				if (result == null)
				{
					result = new GameObject("EmuInstance");
					Object.DontDestroyOnLoad(result);
				}

				return result;
			}
		}

		public static void Load()
		{
			HookObject.GetOrAddComponent<EmuInstance>();
		}
	}
}
