using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		int currentState = 1;
		string mathOperator;
		double firstNumber, secondNumber;

		public MainPage()
		{
			InitializeComponent();
			OnClear(this, null);
		}

		void OnSelectNumber(object sender, EventArgs e)
		{
		}

		void OnSelectOperator(object sender, EventArgs e)
		{
		}

		void OnClear(object sender, EventArgs e)
		{
		}

		void OnCalculate(object sender, EventArgs e)
		{
		}

	}
}