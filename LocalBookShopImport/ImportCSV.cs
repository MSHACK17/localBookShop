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
                    String[] line;
                    while (csvReader.Peek() >= 0)
                    {
                        line = csvReader.ReadLine().Split(';');
                        var book = Database.findBook(line[0]);
                        if (book != null)
                        {
                            var storage = Database.Create(Table.Storage);
                            storage["id_shop"] = shopId;
                            storage["id_book"] = book["id"];
                            storage["amount"] = line[1];
                            Database.Save(storage);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("CSV-Datei nicht gefunden!");
                    return false;
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fehler: " + e.ToString());
            }
            return false;
        }        
    }
}