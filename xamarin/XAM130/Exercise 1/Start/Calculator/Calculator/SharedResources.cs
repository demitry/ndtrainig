using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
	public static class SharedResources
	{
		public static Color OpButtonBkColor
		{
			get { return Color.FromRgb(0xff, 0xa5, 0); }
		}

		public static Color NumberBgColor
		{
			get { return Color.White; }
		}
		public static Color ClearBgColor
		{
			get { return Color.Gray; }
		}

		public static Color OpButtonTextColor
		{
			get { return Color.White; }
		}
		public static Color NumberButtonTextColor
		{
			get { return Color.Black; }
		}

		public static double ButtonFontSize
		{
			get { return 36; }
		}
		public static double LabelFontSize
		{
			get { return 50; }
		}

	}
}
