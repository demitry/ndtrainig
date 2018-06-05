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

		//[Get("/cache")]
		//Task<HttpResponseMessage> CheckIfModified([Header("If-Modified-Since")] string lastUpdateAtString, CancellationToken ctx);

		//[Post("/post")]
		//Task<HttpResponseMessage> FormPost([Body(BodySerializationMethod.UrlEncoded)] /*FormData*/MultipartFormDataContent data, CancellationToken ctx);

		//[Get("/anything/{data}")]
		//Task<HttpResponseMessage> Anything(string data);


	}
}