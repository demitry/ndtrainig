using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace AsyncAwaitTest
{
	internal class Worker
	{
		public bool IsComplete { get; private set; }

		internal void DoWork()
		{
			this.IsComplete = false;
			Console.WriteLine("Doing Work");

			LongOperation();

			Console.WriteLine("\nWork Completed");

			IsComplete = true;
		}

		private void LongOperation()
		{
			Console.WriteLine("Working!");
			Thread.Sleep(2000);
		}
	}
}