﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using LimeBean;

namespace LocalBookShopImport.Models
{
    public class Book : Bean
    {
        public Book() : base("book") { }

        protected override void AfterStore()
        {
            GetApi().Transaction(() =>
            {
                foreach (var author in Authors)
                {
                    if (string.IsNullOrWhiteSpace(author?.Url))
                    {
                        return false;
                    }
                    
                    var dbAuthor = GetApi().FindOne<Author>("WHERE ob_url = {0}", author.Url);

                    if (dbAuthor == null)
                    {
                        GetApi().Store(author);
                        dbAuthor = author;
                    }

                    var relation = GetApi().Dispense("book_author");
                    relation["id_author"] = dbAuthor.Id;
                    relation["id_book"] = Id;

                    GetApi().Store(relation);
                }

                return true;
            });
        }

        public List<Author> Authors { get; set; }
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