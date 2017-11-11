using System;
using System.Data;

namespace LocalBookShopImport
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*
            OpenLibraryBooksAPI api = new OpenLibraryBooksAPI();
            var book = api.SearchBook("");
            Database.Save(book);
            */
            /*
            var book = Database.CreateBeam<Book>();
            book.Title = "tt";
            book.Author = Database.CreateBeam<Author>();
            book.Author.Name = "pw";
            book.Author.Url = "123";
  
            var book = Database.Create(Table.Book);
            book["title"] = "test! ;)";

            Database.Save(book);
            */
            
            ImportCSV importCsv = new ImportCSV();
            if (importCsv.ReadCsv(4, @"..\..\buecher.csv"))
            {
                Console.WriteLine("Import erfolgreich");
            }
            else
            {
                Console.WriteLine("Import nicht erfolgreich");
            }
            //NancySelfHost host = new NancySelfHost();
            //host.Start();
            //Console.ReadKey();
            //host.Stop();


            
        }
    }
}