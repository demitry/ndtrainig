using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NetStatus
{
	public class NoNetworkPage : ContentPage
	{
		public NoNetworkPage ()
		{
			Content = new StackLayout {
				Children = {
					new Label {
						Text = "No Network Connection Available!",
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						TextColor = Color.Blue,					}
				}
			};
		}
	}
}