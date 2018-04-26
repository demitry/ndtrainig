using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSubTutorial.NotificationService
{
	class NotificationService
	{
		public NotificationService(IUserRepository userRepository, INotifier notifier, ILogger logger)
		{
			_userRepository = userRepository;
			_notifier = notifier;
			_logger = logger;
		}

		private readonly IUserRepository _userRepository;
		private readonly INotifier _notifier;
		private readonly ILogger _logger;

		public void NotifyUser(int userId)
		{
			User user;
			try
			{
				user = _userRepository.GetById(userId);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return;
			}
			if (user.HasActivatedNotification)
			{
				_notifier.Notify(user);
			}
		}
	}
}
