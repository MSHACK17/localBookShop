using LimeBean;

namespace LocalBookShopImport.Model
{
    public class Storage : Bean
    {
        public Storage() : base("storage") { }
        
        public int Id => Get<int>("id");
        
        public int ShopId
        {
            get { return Get<int>("id_shop"); }
            set { Put("id_shop", value); }
        }
        
        public int BookId
        {
            get { return Get<int>("id_book"); }
            set { Put("id_book", value); }
        }
        
        public int Amount
        {
            get { return Get<int>("amount"); }
            set { Put("amount", value); }
        }
    }
}