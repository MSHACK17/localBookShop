using LimeBean;

namespace LocalBookShopImport.Model
{
    public class Genre : Bean
    {
        public Genre() : base("genre") { }
        
        public int Id => Get<int>("id");

        public string Name
        {
            get { return Get<string>("name"); }
            set { Put("name", value); }
        }

    }
}