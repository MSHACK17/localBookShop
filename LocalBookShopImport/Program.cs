using LocalBookShopImport.Models;

namespace LocalBookShopImport
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var book = Database.CreateBeam<Book>();
            book.Title = "tt";
            book.Author = Database.CreateBeam<Author>();
            book.Author.Name = "pw";
            book.Author.Url = "123";
            
            Database.Save(book);
        }
    }
}