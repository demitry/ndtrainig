using System;
using System.Windows.Input;

namespace NSubTutorial
{
	internal class CommandRunner
	{
		private ICommand command;

		public CommandRunner(ICommand command)
		{
			this.command = command;
		}

		internal void RunCommand()
		{
			throw new NotImplementedException();
		}
	}
}