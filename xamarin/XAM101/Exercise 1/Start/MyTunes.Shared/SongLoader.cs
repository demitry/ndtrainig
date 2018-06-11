using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace MyTunes
{
	public static class SongLoader
	{
		const string Filename = "songs.json";

		public static async Task<IEnumerable<Song>> Load()
		{
			using (var reader = new StreamReader(OpenData())) {
				return JsonConvert.DeserializeObject<List<Song>>(await reader.ReadToEndAsync());
			}
		}

		private static Stream OpenData()
		{
#if __IOS__
			return File.OpenRead(Filename);
#elif __ANDROID__
			return Android.App.Application.Context.Assets.Open(Filename);
#elif WINDOWS_UWP
			var sf = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(Filename);
			return await sf.OpenStreamForReadAsync();
#else
			// TODO: add code to open file here.
			Debug.WriteLine("DPOL: Unknown architecture, determine how to open file in this case.");
			return null;
#endif
		}
	}
}

