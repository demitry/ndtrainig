using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetStatus
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NetworkViewPage : ContentPage
	{
		public NetworkViewPage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			//ConnectionDetails.Text = CrossConnectivity.Current.ConnectionTypes.First().ToString();

			if (CrossConnectivity.Current != null)
			{
				CrossConnectivity.Current.ConnectivityChanged += UpdateNetworkInfo;
			}

			UpdateNetworkInfo();
		}

		private void UpdateNetworkInfo(object sender, ConnectivityChangedEventArgs e)
		{
			UpdateNetworkInfo();
		}

		private void UpdateNetworkInfo()
		{
			if (CrossConnectivity.Current != null && CrossConnectivity.Current.ConnectionTypes != null)
			{
				var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
				ConnectionDetails.Text = connectionType.ToString();
			}
		}
	}
}