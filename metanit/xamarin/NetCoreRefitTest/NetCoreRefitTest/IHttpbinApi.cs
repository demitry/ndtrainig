using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreRefitTest
{
	[Headers("Accept: application/json")]
	public interface IHttpbinApi
	{
		[Get("/basic-auth/{username}/{password}")]
		Task<AuthResult> BasicAuth(string username, string password, [Header("Authorization")] string authToken, CancellationToken ctx);

		[Get("/cache")]
		Task<HttpResponseMessage> CheckIfModified([Header("If-Modified-Since")] string lastUpdateAtString, CancellationToken ctx);

		[Post("/post")]
		Task<HttpResponseMessage> FormPost([Body(BodySerializationMethod.UrlEncoded)] /*FormData*/MultipartFormDataContent data, CancellationToken ctx);

		[Get("/anything/{data}")]
		Task<HttpResponseMessage> Anything(string data);
	}
}
