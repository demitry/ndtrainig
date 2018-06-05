using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreRefitTest
{
	class Program
    {
		public static void TestJsonServerAsync()
		{
			var jsonServerClient = new HttpClient()
			{
				BaseAddress = new Uri("http://jsonplaceholder.typicode.com")
			};

			var jsonServerApiService = RestService.For<IHttpJsonPlaceholder>(jsonServerClient);

			CancellationTokenSource cts = new CancellationTokenSource();

			var getPostsResult = jsonServerApiService.GetPosts(cts.Token);

			getPostsResult.Wait();

			Console.WriteLine(getPostsResult.Result);
			HttpResponseMessage response = getPostsResult.Result;
			Task<string> taskstr = response.Content.ReadAsStringAsync();
			taskstr.Wait();
			Console.WriteLine(taskstr.Result);

			List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(taskstr.Result);
			//Posts posts = new JavaScriptSerializer().Deserialize<Posts>(taskstr.Result);

			foreach (var p in posts)
			{
				Console.WriteLine(p.id + " " + p.title);
			}
		}

		public void Test()
		{
			//var gitHubApi = RestService.For<IGitHubApi>("https://api.github.com");

			//var demitryUser = gitHubApi.GetUser("demitry");


			//var client = new HttpClient(/*new HttpMessageHandler()*/)
			//{
			//	BaseAddress = new Uri("http://httpbin.org")
			//};
			//var _httpbinApiService = RestService.For<IHttpbinApi>(client);

			//CancellationTokenSource cts = new CancellationTokenSource();
			//var autResult = _httpbinApiService.BasicAuth("user", "password", "autToken", cts.Token);


			//var anythingResult = _httpbinApiService.Anything("My Data");
			//Console.WriteLine(anythingResult.Result);

			/////////////////////////////////////////////////////////////////

			//await response.Content.ReadAsStringAsync();
			//Stream receiveStream = response.GetResponseStream();
			//StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
			//string strResponse = readStream.ReadToEnd();
		}

		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			TestJsonServerAsync();

			Console.ReadKey();
		}

		
    }
}
