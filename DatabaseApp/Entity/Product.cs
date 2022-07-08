namespace DatabaseApp.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Pd_name { get; set; }
        public int Pd_quantity { get; set; }
        public int Pd_price { get; set; }
        public int Depot_id { get; set; }


        public Order_item order_Item { get; set; }



    }
}
