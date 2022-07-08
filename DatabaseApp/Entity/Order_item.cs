namespace DatabaseApp.Entity
{
    public class Order_item
    {
        public int Id { get; set; }
        public int Pd_id { get; set; }
        public int Quantity { get; set; }


        public Product product { get; set; }
            
    }
}
