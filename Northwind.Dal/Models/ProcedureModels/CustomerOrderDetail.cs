namespace Northwind.Dal.Models.ProcedureModels
{
    public class CustomerOrderDetail
    {
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int Discount { get; set; }

        public decimal ExtendedPrice { get; set; }
    }
}
