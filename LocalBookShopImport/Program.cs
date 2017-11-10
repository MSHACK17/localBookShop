using LocalBookShopImport.Models;

using System;

namespace LocalBookShopImport
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var book = Database.CreateBeam<Book>();
            book.Title = "tt";
            book.Author = Database.CreateBeam<Author>();
            book.Author.Name = "pw";
            book.Author.Url = "123";
            
            /*
            OpenLibraryBooksAPI api = new OpenLibraryBooksAPI();
            DataTable dttemp = api.SearchBook("0072435097").Result;
            Console.Write(dttemp.ToString());
            var book = Database.Create(Table.Book);
            book["title"] = "test! ;)";

            Database.Save(book);
            */
            ImportCSV importCsv = new ImportCSV();
            if (importCsv.readCSV(@"..\..\buecher.csv", 1))
            {
                Console.WriteLine("Import erfolgreich");
            }
            else
            {
                Console.WriteLine("Import nicht erfolgreich");
            }
            
        }
    }
}