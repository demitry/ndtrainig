using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions;

namespace NSubTutorial.NotificationService
{
	//https://codingjourneyman.com/2015/09/07/easy-mocking-with-nsubstitute/


	//xUnit.net does not require an attribute for a test class; it looks for all test methods in all public (exported) classes in the assembly.
	//https://xunit.github.io/docs/comparisons

	public class NotificationServiceTester
	{
		public void DoTest()
		{
			//So the first question is: how to create mock(or substitute) with NSubstitute? As a reminder it is done like this with Moq:
			Mock<IUserRepository> mockRepository = new Mock<IUserRepository>();
			IUserRepository repo = mockRepository.Object;

			//With NSubstitute the concept is similar but with one noticeable change.
			IUserRepository userRepository = Substitute.For<IUserRepository>();
		}
	}


	public class NotificationService_Should
	{
		private readonly NotificationService _service;

		private readonly IUserRepository _userRepository;
		private readonly INotifier _notifier;
		private readonly ILogger _logger;

		public NotificationService_Should()
		{
			_userRepository = Substitute.For<IUserRepository>();
			_notifier = Substitute.For<INotifier>();
			_logger = Substitute.For<ILogger>();

			_service = new NotificationService(_userRepository, _notifier, _logger);

			_userRepository
				.GetById(Arg.Is<int>(i => i < 10))
				.Returns(new User { HasActivatedNotification = true });

			_userRepository
				.GetById(Arg.Is<int>(i => i >= 10))
				.Returns(new User { HasActivatedNotification = false });

			_userRepository
				.GetById(Arg.Is<int>(i => i < 0))
				.Returns(user => { throw new InvalidUserIdException(); });
		}

		[Fact(DisplayName = "NotifyUser calls the repository")]
		public void Call_Repository()
		{
			_userRepository.GetById(Arg.Any<int>()).Returns(new User());
			_service.NotifyUser(1);
			_userRepository.Received().GetById(Arg.Any<int>());
		}

		[Fact(DisplayName = "NotifyUser calls notifier if user has activated the notifications")]
		public void Call_Notifier_When_User_Has_Activated_Notification()
		{
			_service.NotifyUser(1);
			_notifier.Received().Notify(Arg.Any<User>());
		}

		[Fact(DisplayName = "NotifyUser does not call notifier if user has not activated the notifications")]
		public void Does_Not_Call_Notifier_When_User_Has_Not_Activated_Notification()
		{
			_service.NotifyUser(11);
			_notifier.DidNotReceive().Notify(Arg.Any<User>());
		}

		[Fact(DisplayName = "NotifyUser calls logger when an exception is thrown")]
		public void Call_Logger_When_An_Exception_Is_Thrown()
		{
			_service.NotifyUser(-1);
			_logger.Received().Error("Given user ID is invalid");
		}

	}
}
