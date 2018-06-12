using Android.App;
using Android.OS;
using System.Linq;

namespace MyTunes
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : ListActivity
	{
		protected async override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);


			/*
			1.	Locate the OnCreate method in MainActivity.cs.
			2.	Comment out the existing ListAdapter assignment.
			3.	Load the data using SongLoader.Load. This method uses the Task based Async pattern; you will need to await the call and decorate OnCreate with the async keyword.
			4.	Call ToList on the IEnumerable<Song> returned from SongLoader.Load - we'll use this in the next step. (This will require the System.Linq namespace.)
			5.	Create a new ListAdapter<Song> and assign the following properties:
			6.	Set the DataSource property to your new list.
			7.	Set the TextProc to a lambda that returns the song name: s => s.Name.
			8.	Set the DetailTextProc to a lambda that returns the artist and album: s => s.Artist + " - " + s.Album.
			9.	Assign the object to the ListAdapter property.
			*/
			//ListAdapter = new ListAdapter<string>() {
			//	DataSource = new[] { "One", "Two", "Three" }
			//};

			// Load the data
			var data = await SongLoader.Load();

			ListAdapter = new ListAdapter<Song>()
			{
				DataSource = data.ToList(),
				TextProc = s => s.Name,
				DetailTextProc = s => s.Artist + " - " + s.Album
			};

		}
	}
}


