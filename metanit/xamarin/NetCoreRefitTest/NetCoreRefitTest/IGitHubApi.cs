using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreRefitTest
{
	public interface IGitHubApi
	{
		[Get("/users/{user}")]
		Task<User> GetUser(string user);
	}
}
