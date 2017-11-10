using System;
using System.Collections.Generic;
 using System.Data;

namespace LocalBookShopImport
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            OpenLibraryBooksAPI api = new OpenLibraryBooksAPI();
            DataTable dttemp = api.SearchBook("0072435097").Result;
            Console.Write(dttemp.ToString());
            var book = Database.Create(Table.Book);
            book["title"] = "test! ;)";

            Database.Save(book);
        }
    }
}