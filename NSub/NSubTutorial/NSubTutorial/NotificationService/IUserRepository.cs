namespace NSubTutorial.NotificationService
{
	public interface IUserRepository
	{
		User GetById(int userId);
	}
}