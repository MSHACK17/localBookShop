using System;
using System.Data;
using LocalBookShopImport.Model;

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
            /*
            ImportCSV importCsv = new ImportCSV();
            if (importCsv.ReadCsv(4, @"..\..\buecher.csv"))
            {
                Console.WriteLine("Import erfolgreich");
            }
            else
            {
                Console.WriteLine("Import nicht erfolgreich");
            }
            */
            
            /*
             while (true)
            {
                try
                {
                    var book = Database.FindBookByIsbn10IsNull();
                    if (book != null)
                    {
                        book.ISBN10 = IBAN.ConvertIsbn13ToIsbn10(book.ISBN13);
                        Database.Save(book);
                    }
                    else
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(500);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            */
            /*
            while (true)
            {
                try
                {
                    var book = Database.FindBookByIsbn13IsNull();
                    if (book != null)
                    {
                        book.ISBN13 = IBAN.ConvertIsbn10ToIsbn13(book.ISBN10);
                        Database.Save(book);
                    }
                    else
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(500);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            */
            
            //string iban13 = IBAN.ConvertIsbn10ToIsbn13("300001876X");
            //string iban10 = IBAN.ConvertIsbn13ToIsbn10("9781402219504");



            //NancySelfHost host = new NancySelfHost();
            //host.Start();
            //Console.ReadKey();
            //host.Stop();



        }
    }
}