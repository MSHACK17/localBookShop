using System;
using System.Security.Cryptography.X509Certificates;
using LimeBean;

namespace LocalBookShopImport.Models
{
    public class Book : Bean
    {
        public Book() : base("book") { }

        protected override void BeforeStore()
        {
            if (string.IsNullOrWhiteSpace(Author?.Url))
            {
                throw new Exception("Author is empty!");
            }
        }

        protected override void AfterStore()
        {
            var author = GetApi().FindOne<Author>("WHERE ob_url = {0}", Author.Url);

            if (author == null)
            {
                GetApi().Store(Author);
                author = Author;
            }

            var relation = GetApi().Dispense("book_author");
            relation["id_author"] = author.Id;
            relation["id_book"] = Id;

            GetApi().Store(relation);
        }

        public Author Author { get; set; }
        public int Id => Get<int>("id");

        public string Title
        {
            get { return Get<string>("title"); }
            set { Put("title", value); }
        }
        
        public string ImageUrl
        {
            get { return Get<string>("image_url"); }
            set { Put("image_url", value); }
        }
        
        public DateTime PublicationDate
        {
            get { return Get<DateTime>("publication_date"); }
            set { Put("publication_date", value); }
        }
        
        public string ISBN10
        {
            get { return Get<string>("isbn_10"); }
            set { Put("isbn_10", value); }
        }

        
        public string ISBN13
        {
            get { return Get<string>("isbn_13"); }
            set { Put("isbn_13", value); }
        }

        public string Description
        {
            get { return Get<string>("description"); }
            set { Put("description", value); }
        }
    }
}