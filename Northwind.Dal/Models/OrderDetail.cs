namespace Northwind.Dal.Models
{
    public class OrderDetail
    {
        public Product Product { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public float Discount { get; set; }
    }
}