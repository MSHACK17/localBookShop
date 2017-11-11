﻿using System;
 using System.Globalization;
 using System.Linq;
 using System.Net.Http;
 using System.Text;
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
            
            if (jsonarray?["small"] != null)
            {
                book.ImageUrl = (string) jsonarray["small"];   
            }
            
            DateTime date;
            if (DateTime.TryParse((string) jsonarray["publish_date"], out date))
            {
                book.PublicationDate = date;
            }
            
            if (jsonarray["identifiers"]?["isbn_10"] != null)
            {
                book.ISBN10 = (string) jsonarray["identifiers"]["isbn_10"].First;   
            }
            
            if (jsonarray["identifiers"]?["isbn_13"] != null)
            {
                 book.ISBN13 = (string) jsonarray["identifiers"]["isbn_13"].First;   
            }
            if (jsonarray?["authors"] != null)
            {
                foreach (var item in jsonarray["authors"])
                {
                    var author = Database.CreateBeam<Author>();
                    author.Name = (string) item["name"];
                    author.Url = (string) item["url"];
                    book.Authors.Add(author);
                }   
            }
            
            if (jsonarray["subtitle"] != null)
            {
                book.Description = (string) jsonarray["subtitle"];
            }
            if (jsonarray?["subjects"] != null)
            {
                foreach (var item in jsonarray["subjects"])
                {
                    book.Genre.Add((string) item["url"]);
                }                
            }

            book.Publisher = (string) jsonarray["publishers"].First["name"];
            
            return book;
        }
    }
}