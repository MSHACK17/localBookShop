using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace LocalBookShopImport
{
    public class OpenLibraryBooksAPI : IDisposable
    {
        private HttpClient httpclient;
        private HttpClientHandler httphandler;
        private CookieContainer cookies;

        public OpenLibraryBooksAPI()
        {
            httphandler = new HttpClientHandler();
            cookies = new CookieContainer();
            httphandler.CookieContainer = cookies;
            httpclient = new HttpClient(httphandler) {Timeout = TimeSpan.FromSeconds(60)};
        }

        public async Task<DataTable> SearchBook(string isbn)
        {
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
            {
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
                

                
                
                
                Console.WriteLine(author);
                Console.WriteLine(title);
                
                
                //object obj  = JsonConvert.DeserializeObject(content); 
                //data = JsonConvert.DeserializeObject<DataTable>(content);
                return null;
            }
            return null;
        }
        

        public void Dispose()
        {
            httpclient?.CancelPendingRequests();
            httpclient?.Dispose();
            httphandler?.Dispose();
        }
    }
}