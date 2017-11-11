using LimeBean;

namespace LocalBookShopImport.Model
{
    public class Publisher : Bean
    {
        public Publisher() : base("publisher") { }
        
        public int Id => Get<int>("id");

        public string Name
        {
            get { return Get<string>("name"); }
            set { Put("name", value); }
        }

    }
}