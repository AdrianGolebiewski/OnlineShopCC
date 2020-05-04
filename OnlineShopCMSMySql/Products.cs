
namespace OnlineShopCMSMySql
{
    // publiczne pola to nazwy kolumn w tabeli

    public class Products
    {
        public int product_id { get; set; }
        public string category { get; set; }
        public string manufacturer { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
        public string product_index { get; set; }

        public Products(int product_id, string category, string manufacturer, string color, string size, float price, int quantity, string description, string product_index)
        {
            this.product_id = product_id;
            this.category = category;
            this.manufacturer = manufacturer;
            this.color = color;
            this.size = size;
            this.price = price;
            this.quantity = quantity;
            this.description = description;
            this.product_index = product_index;
        }

    }
}
