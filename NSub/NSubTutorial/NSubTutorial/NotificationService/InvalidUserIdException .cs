using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSubTutorial.NotificationService
{
	class InvalidUserIdException : Exception
	{
		public override string Message
		{
			get { return "Given user ID is invalid"; }
		}
	}
}
