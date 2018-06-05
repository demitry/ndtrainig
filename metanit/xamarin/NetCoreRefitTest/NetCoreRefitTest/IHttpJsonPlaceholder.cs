using Refit;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreRefitTest
{
	[Headers("Accept: application/json")]
	public interface IHttpJsonPlaceholder
	{
		[Get("/posts")]
		Task<HttpResponseMessage> GetPosts(CancellationToken ctx);
	}
}