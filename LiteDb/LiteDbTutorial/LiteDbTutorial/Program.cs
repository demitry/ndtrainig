using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

// 
// Использование NoSQL-хранилища LiteDB в .NET
// https://metanit.com/sharp/articles/ado.net/1.php
// 

namespace LiteDbTutorial
{
	public class Company
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public List<User> Users { get; set; }
	}

	public class DbTester
	{
		public static void TestDb()
		{
			// открывает базу данных, если ее нет - то создает
			using (var db = new LiteDatabase(@"MyData.db"))
			{
				// Получаем коллекцию
				var col = db.GetCollection<Company>("companies");

				var microsoft = new Company { Name = "Microsoft" };
				microsoft.Users = new List<User> { new User { Name = "Bill Gates" } };

				// Добавляем компанию в коллекцию
				col.Insert(microsoft);

				// Обновляем документ в коллекции
				microsoft.Name = "Microsoft Inc.";
				col.Update(microsoft);


				var google = new Company { Name = "Google" };
				google.Users = new List<User> { new User { Name = "Larry Page" } };
				col.Insert(google);

				// Получаем все документы
				var result = col.FindAll();
				foreach (Company c in result)
				{
					Console.WriteLine(c.Name);
					foreach (User u in c.Users)
						Console.WriteLine(u.Name);
					Console.WriteLine();
				}

				// Индексируем документ по определенному свойству
				col.EnsureIndex(x => x.Name);

				col.Delete(x => x.Name.Equals("Google"));

				Console.WriteLine("После удаления Google");
				result = col.FindAll();
				foreach (Company c in result)
				{
					Console.WriteLine(c.Name);
					foreach (User u in c.Users)
						Console.WriteLine(u.Name);
					Console.WriteLine();
				}
			}
		}
	}

	public class User
	{
		public string Name { get; set; }
		public string Position { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			DbTester.TestDb();
			Console.ReadKey();
		}
	}
}
