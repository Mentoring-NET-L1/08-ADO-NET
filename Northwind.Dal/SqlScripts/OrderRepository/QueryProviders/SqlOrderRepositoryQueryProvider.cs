namespace Northwind.Dal.SqlScripts.OrderRepository.QueryProviders
{
    internal class SqlOrderRepositoryQueryProvider : IOrderRepositoryQueryProvider
    {
        public string GetOrders => SqlServer.Queries.GetOrders;

        public string GetDetailedInfo => SqlServer.Queries.GetDetailedInfo;

        public string AddOrder => SqlServer.Queries.AddOrder;

        public string UpdateOrder => SqlServer.Queries.UpdateOrder;

        public string DeleteOrder => SqlServer.Queries.DeleteOrder;

        public string StartProgress => SqlServer.Queries.StartProgress;

        public string CloseOrder => SqlServer.Queries.CloseOrder;

        public string CustOrderHist => "[CustOrderHist]";

        public string CustOrdersDetail => "[CustOrdersDetail]";
    }
}
