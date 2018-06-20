using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookClient.Data
{
	//This is the manager class which wraps the web service.

	public class BookManager
	{
		const string Url = "http://xam150.azurewebsites.net/api/books/";

		private string authorizationKey;

		private async Task<HttpClient> GetClient()
		{
			/*
			1. In the method, create a new HttpClient.
			2. If this is the first time the method has been called, then the authorizationKey field will not be set. In this case, you need to use GetStringAsync with the base URL + login to get the token.
			3. The returned token will have quotes around it which need to be removed. An easy way to do this is to use JsonConvert.DeserializeObject<string>(...). Save the result into the authorizationKey field.
			4. Add an Authorization header to the DefaultRequestHeaders collection of the HttpClient. Use the token as the value.
			5. Add an Accept header to the DefaultRequestHeaders collection of the HttpClient. Use application/json as the value.
			Return the HttpClient object from the method.
			*/

			HttpClient client = new HttpClient();
			if (string.IsNullOrEmpty(authorizationKey))
			{
				authorizationKey = await client.GetStringAsync(Url + "login");
				authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey);
			}

			client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
			client.DefaultRequestHeaders.Add("Accept", "application/json");
			return client;
		}

		public async Task<IEnumerable<Book>> GetAll()
		{
			HttpClient client = await GetClient();
			string result = await client.GetStringAsync(Url);
			return JsonConvert.DeserializeObject<IEnumerable<Book>>(result);
		}

		public async Task<Book> Add(string title, string author, string genre)
		{
			// Use POST to add a book
			Book book = new Book()
			{
				Title = title,
				Authors = new List<string>(new[] { author }),
				ISBN = string.Empty,
				Genre = genre,
				PublishDate = DateTime.Now.Date,
			};
			HttpClient client = await GetClient();
			var response = await client.PostAsync(Url,
				new StringContent(
					JsonConvert.SerializeObject(book),
					Encoding.UTF8, "application/json"));
			return JsonConvert.DeserializeObject<Book>(
					await response.Content.ReadAsStringAsync());		}

		public async Task Update(Book book)
		{
			// Use PUT to update a book
			HttpClient client = await GetClient();
			await client.PutAsync(Url + "/" + book.ISBN,
				new StringContent(
					JsonConvert.SerializeObject(book),
					Encoding.UTF8, "application/json"));
		}

		public async Task Delete(string isbn)
		{
			// Use DELETE to delete a book
			HttpClient client = await GetClient();
			await client.DeleteAsync(Url + isbn);		}
	}
}

