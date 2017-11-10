using System;
using Npgsql;

namespace LocalBookShopImport
{
    public static class Database
    {
        static readonly NpgsqlConnection dbConnection;
        
        static Database()
        {
            dbConnection =
                new NpgsqlConnection(
                    "Host=172.16.2.200;Port=5432;Username=book_system;Password=book123;Database=local_book_shop;");
            
            dbConnection.Open();
        }
                
        public static bool insertBook()
        {
            try
            {
                dbConnection.Open();
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fehler: " + e);
                return false;
            }
        }
    }
}