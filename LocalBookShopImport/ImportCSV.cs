using System;
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;

namespace LocalBookShopImport
{
    public class ImportCSV
    {
        private StreamReader csvReader;

        public Boolean readCSV(string path, int shopId)
        {
            try
            {
                if (File.Exists(path))
                {
                    csvReader = new StreamReader(path);
                    while (csvReader.Peek() >= 0)
                    {
                        String[] line = csvReader.ReadLine().Split(';');
                        var book = Database.findBook(line[0]);
                        var storage = Database.Create(Table.Storage);
                        storage["id_shop"] = shopId;
                        storage["id_book"] = book["id"];
                        storage["amount"] = line[1];
                        Database.Save(storage);
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
                Console.WriteLine("Fehler: " + e.ToString());
            }
            return false;
        }        
    }
}