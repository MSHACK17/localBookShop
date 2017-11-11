using LimeBean;

namespace LocalBookShopImport.Model
{
    public class Author : Bean
    {
        public Author() : base("author") { }

        public int Id => Get<int>("id");

        public string Name
        {
            get { return Get<string>("name"); }
            set { Put("name", value); }
        }

        public string Url
        {
            get { return Get<string>("ob_url"); }
            set { Put("ob_url", value); }
        }

    }
}