using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace FirstApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new MainPage();
			// The root page of your application
			var layout = new StackLayout
			{
				VerticalOptions = LayoutOptions.Center,
				Children = {
					new Label {
						HorizontalTextAlignment = TextAlignment.Center,
						Text = "Welcome to Xamarin Forms!"
					}
				}
			};

			MainPage = new ContentPage
			{
				Content = layout
			};

			Button button = new Button
			{
				Text = "Click Me"
			};

			button.Clicked += async (s, e) => {
				await MainPage.DisplayAlert("Alert", "You clicked me", "OK");

				/*
				 Place a breakpoint in the button clicked handler and tap the button again. 
				 While the debugger is stopped, examine the call stack. 
				 For Android, at the bottom of the call stack you should find native handlers, 
				 they will clearly come from java.widgets, 
				 in UWP, you will see a XAML button and in iOS you will see some native iOS code methods. 
				 This is bubbled up through a view renderer that translates the platform-agnostic Button type we created 
				 into a native, platform-specific button.
				 */
			};

			layout.Children.Add(button);
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
