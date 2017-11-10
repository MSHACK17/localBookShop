using System;
using System.IO;
using LocalBookShopImport.Models;

namespace LocalBookShopImport
{
    public class ImportCSV
    {
        private StreamReader csvReader;
        private OpenLibraryBooksAPI api = new OpenLibraryBooksAPI();

        public bool ReadCsv(string path, int shopId)
        {
            try
            {
                if (File.Exists(path))
                {
                    csvReader = new StreamReader(path);
                    string line;
                    
                    while ((line = csvReader.ReadLine()) != null)
                    {
                        var split = csvReader.ReadLine()?.Split(';');

                        if (split != null && line.Length == 2)
                        {
                            InsertBookRelation(shopId, split[0], int.Parse(split[1]));
                        }
                    }

                    return true;
                }

                Console.WriteLine("CSV-Datei nicht gefunden!");
                return false;
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
                book = api.SearchBook(bookIsbn).Result;
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