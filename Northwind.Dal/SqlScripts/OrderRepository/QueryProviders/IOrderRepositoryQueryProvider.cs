namespace Northwind.Dal.SqlScripts.OrderRepository.QueryProviders
{
    public interface IOrderRepositoryQueryProvider
    {
        string GetOrders { get; }

        string GetDetailedInfo { get; }

        string AddOrder { get; }

        string UpdateOrder { get; }

        string DeleteOrder { get; }

        string StartProgress { get; }

        string CloseOrder { get; }

        string CustOrderHist { get; }

        string CustOrdersDetail { get; }
    }
}
