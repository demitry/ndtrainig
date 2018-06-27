using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestImageSubmit
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private async Task TakePictureButton_ClickedAsync(object sender, EventArgs e)
		{
			await CrossMedia.Current.Initialize();

			if( !CrossMedia.Current.IsCameraAvailable ||
				!CrossMedia.Current.IsTakePhotoSupported)
			{
				await DisplayAlert("No Camera", "No Camera available", "OK");
				return;
			}

			var file = await CrossMedia.Current.TakePhotoAsync(
				new Plugin.Media.Abstractions.StoreCameraMediaOptions
				{
					SaveToAlbum = true,
					Name = "test.jpg"
				});

			if (file == null)
				return;
		}

		private async void UploadPictureButton_Clicked(object sender, EventArgs e)
		{
			if(!CrossMedia.Current.IsPickPhotoSupported)
			{
				await DisplayAlert("No upload", "Picking a photo is not supported", "OK");
				return;
			}

			var file = await CrossMedia.Current.PickPhotoAsync();

			if(file == null)
			{
				return;
			}

			Image1.Source = ImageSource.FromStream(() => file.GetStream());
		}

		private async void TakePictureButton_Clicked(object sender, EventArgs e)
		{
			await CrossMedia.Current.Initialize();

			if (!CrossMedia.Current.IsCameraAvailable ||
				!CrossMedia.Current.IsTakePhotoSupported)
			{
				await DisplayAlert("No Camera", "No Camera available", "OK");
				return;
			}

			var file = await CrossMedia.Current.TakePhotoAsync(
				new Plugin.Media.Abstractions.StoreCameraMediaOptions
				{
					SaveToAlbum = true,
					Name = "test.jpg"
				});

			if (file == null)
			{
				return;
			}

			Image1.Source = ImageSource.FromStream(() => file.GetStream());
		}
	}
}
