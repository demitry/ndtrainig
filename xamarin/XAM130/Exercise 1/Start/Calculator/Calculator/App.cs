using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//As a final step, let's turn on the XAML compiler XAMLC to compile our XAML pages.
//	1. Add the XamlCompilation attribute to App.cs
// 	2. Pass in the option to compileXamlCompilationOptions.Compile.
[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Calculator
{
	public class App : Application
	{
		public App()
		{
			// The root page of your application
            MainPage = new MainPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
