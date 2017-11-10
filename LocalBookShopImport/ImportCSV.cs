using System;
using System.IO;
using System.Linq.Expressions;

namespace LocalBookShopImport
{
    public class ImportCSV
    {
        private StreamReader csvReader;

        public Boolean readCSV(string path)
        {
            try
            {
                if (File.Exists(@path))
                {
                    csvReader = new StreamReader(@path);
                    while (csvReader.Peek() >= 0)
                    {
                        String[] line = csvReader.ReadLine().Split(';');
                        
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