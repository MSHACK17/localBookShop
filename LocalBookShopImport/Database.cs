using System;
using LimeBean;
using LocalBookShopImport.Model;
using Npgsql;

namespace LocalBookShopImport
{
    public static class Database
    {        
        private static readonly BeanApi DbConnection;
        
        static Database()
        {            
            var connection =
                new NpgsqlConnection(
                    "Host=172.16.2.200;Port=5432;Username=book_system;Password=book123;Database=local_book_shop;");
            connection.Open();
            
            DbConnection = new BeanApi(connection); 
        }

        public static int Save(Bean item)
        {
            return (int)DbConnection.Store(item);
        }

        public static T CreateBeam<T>()  where T : Bean, new()
        {
            return DbConnection.Dispense<T>();
        }

        public static Book FindBook(string isbn)
        {
            return DbConnection.FindOne<Book>("WHERE isbn_10 = {0} OR isbn_13 = {0}", isbn);
        }

        public static Storage FindStoreRelation(int shopId, int bookId)
        {
            return DbConnection.FindOne<Storage>("WHERE id_shop = {0} and id_book = {1}", shopId, bookId);
        }

        public static bool DeleteAmount(int shopId)
        {
            try
            {
                DbConnection.Exec("DELETE FROM storage WHERE id_shop = {0}", shopId);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Fehler: " + e);
                return false;
            }
        }

        public static Genre FindGenre(string ObUrl)
        {
            return DbConnection.FindOne<Genre>("WHERE ob_url = {0}", ObUrl);
        }
    }
}