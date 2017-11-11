using System;
using System.IO;
using System.Net.Http;
using LocalBookShopImport.Model;

namespace LocalBookShopImport
{
    public class ImportCSV
    {
        private StreamReader csvReader;
        private OpenLibraryBooksAPI api = new OpenLibraryBooksAPI();

        public bool ReadCsv(int shopId, Stream content)
        {
            csvReader = new StreamReader(content);
            return ReadCsv(shopId, csvReader);
        }

        public bool ReadCsv(int shopId, string path)
        {
            if (File.Exists(path))
            {
                csvReader = new StreamReader(path);
                return ReadCsv(shopId, csvReader);
            }
            
            Console.WriteLine("Plüth sagt das gibt nicht!");
            return false;
        }

        public bool ReadCsv(int shopId, StreamReader conetent)
        {
            try
            {
                csvReader = conetent;
                string line;
                if (!Database.DeleteAmount(shopId))
                {
                    return false;
                }
                
                while (csvReader.Peek() >= 0)
                {
                    var split = csvReader.ReadLine()?.Split(';');

                    if (split != null && split.Length == 2)
                    {
                        InsertBookRelation(shopId, split[0], int.Parse(split[1]));
                    }
                }

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Fehler: " + e);
            }

            return false;
        }

        private void InsertBookRelation(int shopId, string bookIsbn, int amount)
        {
            var book = Database.FindBook(bookIsbn);
            
            if (book == null)
            {
                book = api.SearchBook(bookIsbn);

                // Kein Buch per API gefunden
                if (book == null)
                {
                    return;
                }

                Database.Save(book);
            }

            var relation = Database.FindStoreRelation(shopId, book.Id);

            if (relation == null)
            {
                relation = Database.CreateBeam<Storage>();
                relation.ShopId = shopId;
                relation.BookId = book.Id;
            }

            relation.Amount = amount;
            Database.Save(relation);
        }
    }
}