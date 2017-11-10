namespace LocalBookShopImport
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var book = Database.Create(Table.Book);
            book["title"] = "test! ;)";

            Database.Save(book);
        }
    }
}