using AutoMapper;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreRefitTest
{
	class Program
    {
		public static void TestJsonServerAsync()
		{
			// Test Refit
			// https://github.com/reactiveui/refit
			// 

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

			foreach (var p in posts)
			{
				Console.WriteLine(p.id + " " + p.title);
			}


			// Test Automapper
			// https://github.com/AutoMapper/AutoMapper
			// 
			Mapper.Initialize(cfg => {
				cfg.CreateMap<Post, PostExpanded>()
					.ForMember(m => m.FullInfo, opt => opt.MapFrom(src => string.Join(" ", new List<string>() { src.id, src.title, src.userId, src.body })))
					.ForMember(m => m.SortedBody, opt => opt.MapFrom(src => String.Concat(src.body.OrderBy(c => c))))
					.ForMember(m => m.BodySymbolCount, opt => opt.MapFrom(src => src.body.Length + src.title.Length));
			});

			var autoMapperArray = new List<PostExpanded>();
			foreach (var p in posts)
			{
				autoMapperArray.Add(Mapper.Map<Post, PostExpanded>(p));
			}

			autoMapperArray.ForEach(p => Console.WriteLine(p.BodySymbolCount + " - " + p.SortedBody.Substring(0, 90)));

			/*
			 * https://www.codeproject.com/Articles/986460/What-is-Automapper
			 * 
			 Can you give some real time scenarios of the use of Automapper?
				When you are moving data from ViewModel to Model in projects like MVC.
				When you are moving data from DTO to Model or entity objects and vice versa.
			 *
			 * https://www.codeproject.com/Articles/814869/AutoMapper-tips-and-tricks
			 Most developers aren’t using AutoMapper to its full potential, rarely straying away from Mapper.Map.
			 There are a multitude of useful tidbits, including; 
			 - Projection, 
			 - Configuration Validation, 
			 - Custom Conversion, 
			 - Value Resolvers,
			 - Null Substitution, 
			 which can help simplify complex logic when used correctly.

			 */
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
