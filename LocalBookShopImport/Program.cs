using System;
using System.Collections.Generic;

namespace LocalBookShopImport
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            database database = new database();
            if (database.connTest())
            {
                Console.WriteLine("DB steht!");   
            }
            else
            {
                Console.WriteLine("DB geht nicht!"); 
            }
        }
    }
}