﻿using System;
 using System.Globalization;
 using System.Linq;
 using LocalBookShopImport.Model;
 using Newtonsoft.Json.Linq;
 using RestSharp;

namespace LocalBookShopImport
{
    public class OpenLibraryBooksAPI
    {
        public Book SearchBook(string isbn)
        {
            var client = new RestClient("https://openlibrary.org/api/");

            var request = new RestRequest("books", Method.GET);
            request.AddParameter("bibkeys", "ISBN:" + isbn);
            request.AddParameter("format", "json");
            request.AddParameter("jscmd", "data");

            var restResponse = client.Execute(request);
            var jsonResponse = JObject.Parse(restResponse.Content);
            if (!jsonResponse.HasValues)
            {
                return null;
            }
            var jsonarray = jsonResponse.Properties().First().Value;
            var book = Database.CreateBeam<Book>();
            book.Title = (string) jsonarray["title"];
            book.ImageUrl = (string) jsonarray["small"];
            DateTime date;
            if (DateTime.TryParse((string) jsonarray["publish_date"], out date))
            {
                book.PublicationDate = date;
            }
            book.ISBN10 = (string) jsonarray["identifiers"]["isbn_10"].First;
            book.ISBN13 = (string) jsonarray["identifiers"]["isbn_13"].First;
            
            return book;
        }
    }
}