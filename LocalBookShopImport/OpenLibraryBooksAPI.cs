﻿using System;
 using System.Globalization;
 using System.Linq;
 using LocalBookShopImport.Models;
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
            request.AddParameter("jscmd","data");
            
            var restResponse = client.Execute(request);
            var jsonResponse = JObject.Parse(restResponse.Content);

            var jsonarray = jsonResponse.Properties().First().Value;
            var book = Database.CreateBeam<Book>();
            book.Title = (string)jsonarray["title"];
            book.ImageUrl = (string) jsonarray["small"];
            book.PublicationDate = DateTime.ParseExact((string)jsonarray["publish_date"], "DD-MM-YYYY",CultureInfo.InvariantCulture);
            book.ISBN10 = (string) jsonarray["identifiers"]["isbn_10"].First;
            book.ISBN13 = (string) jsonarray["identifiers"]["isbn_13"].First;
            
            return null;


            /*
            string url = @"https://openlibrary.org/api/books?bibkeys=ISBN:" + System.Net.WebUtility.UrlEncode(isbn) + "&format=json&jscmd=data";
            HttpResponseMessage httpresponsemsg = null;
            //Book returnBook = new Book();
            

            bool Timeout = true;
            try
            {
                httpresponsemsg = await httpclient.GetAsync(url);
                Timeout = false;
            }
            catch (Exception e)
            {
                Timeout = true;
                return null;
            }
            if(httpresponsemsg.IsSuccessStatusCode)
            
                string content = await httpresponsemsg.Content.ReadAsStringAsync();
                Console.Write(content);
                if (content == "{}")
                {
                    return null;
                }
                //content = "[" + content;
                //content = content + "]";
                //DataTable data;
                JObject data = JObject.Parse(content);
                string isbn2 = data.Properties().First().Name;
                
                //string author = data.ToString();
                JObject book = (JObject)data[isbn2];
                string title = book["title"].ToString();

                JObject identifiers = (JObject)book["identifiers"];
                string isbn10 = "";
                string isbn13 = "";
                //JObject identifiers2 = (JObject)identifiers.First;
                foreach (JProperty property in identifiers.Properties())
                {
                    if (property.Name == "isbn_13")
                    {
                        isbn13 = property.Value.ToString();

                    } else if (property.Name == "isbn_10")
                    {
                        isbn10 = property.Value.ToString();
                    }
                   Console.WriteLine(property.Name + " - " + property.Value);
                }

                string publisheddatestr = book["publish_date"].ToString();
                DateTime publishedate = DateTime.Today;
                DateTime.TryParseExact(publisheddatestr, "MMMM YYYY", System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out publishedate);
                

                
                
                
                //Console.WriteLine(author);
                Console.WriteLine(title);
                
                
                //object obj  = JsonConvert.DeserializeObject(content); 
                //data = JsonConvert.DeserializeObject<DataTable>(content);
                return null;
            }
        */

        }
        /*
        public void Dispose()
        {
            httpclient?.CancelPendingRequests();
            httpclient?.Dispose();
            httphandler?.Dispose();
        }
        */
    }
}