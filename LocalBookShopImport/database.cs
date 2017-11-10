using System;
using Npgsql;

namespace LocalBookShopImport
{
    public class database
    {
        NpgsqlConnection conn = new NpgsqlConnection("Host=172.16.2.200;Port=5432;Username=book_system;Password=book123;Database=local_book_shop;");

        public Boolean connTest()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception e)
            {
                
                Console.WriteLine("Fehler: " + e.ToString());
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public Boolean insertBook()
        {
            try
            {
                conn.Open();
                
                return true;
            }
            catch (Exception e)
            {
                return false;
                Console.WriteLine("Fehler: " + e);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}