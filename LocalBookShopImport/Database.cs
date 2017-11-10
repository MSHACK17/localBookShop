using LimeBean;
using Npgsql;

namespace LocalBookShopImport
{
    public enum Table
    {
        Author, Book, Genre, Publisher, Shop, Storage   
    }
    
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

        public static Bean findBook(string isbn)
        {
            return DbConnection.FindOne("book", "where isbn_10 = {0} or isbn_13 = {0}", isbn);
        }
    }
}