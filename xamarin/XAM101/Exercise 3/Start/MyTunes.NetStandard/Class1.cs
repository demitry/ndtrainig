using System;
using System.Net.Http;

/*
 * Visual Studio is warning us about our use of the HttpClient type.
 * This is because that set of APIs are not available in .NET Standard v1.0. 
 * Attempting to build our project now would result in a build error.
Right-click the library project in the Solution Explorer and chose Properties.
In the Project properties, under Application > Target framework choose .NET Standard 1.1.
Try building your app.
Now that we are targeting the version of .NET Standard that first included the HttpClient APIs, our code will now compile successfully.
 */

namespace MyTunes
{
	public static class SongExtensions
	{

		static HttpClient httpClient = new HttpClient();

		public static string RuinSongName(this string songName)
		{
			return songName.Replace("Crocodile", "Alligator");
		}
	}
}
