using System;
using System.Collections.Generic;

/*
 This is the object representation for a single book. 
 The definition should match the JSON description above. 
 It has public properties defined for each of the passed fields. 
 Json.NET is smart enough to manage camel-casing vs. pascal-casing 
 so you can name the properties with standard C# conventions,
 the key thing is that the names are spelled correctly.
 */
namespace BookClient.Data
{
	public class Book
	{
		public string ISBN { get; set; }
		public string Title { get; set; }
		public List<string> Authors { get; set; }
		public DateTime PublishDate { get; set; }
		public string Genre { get; set; }
	}
}

