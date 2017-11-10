using System;

namespace LocalBookShopImport
{
    internal class Program
    {
        public static void Main(string[] args)
        {
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