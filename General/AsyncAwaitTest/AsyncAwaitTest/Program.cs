using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//https://www.youtube.com/watch?v=6_GTdR0gBVE

namespace AsyncAwaitTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Starting");

			var worker = new Worker();
			worker.DoWork();

			while (!worker.IsComplete)
			{
				Console.Write(".");
				Thread.Sleep(100);
			}

			Console.ReadKey();
		}
	}
}
