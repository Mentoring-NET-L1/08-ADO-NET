using Northwind.Dal.SqlScripts.OrderRepository.QueryProviders;

namespace Northwind.Dal.Repositories
{
    public sealed class SqlOrderRepository : OrderRepository
    {
        public SqlOrderRepository(string connectionString, string provider)
            : base(new SqlOrderRepositoryQueryProvider(), connectionString, provider)
        {
        }
    }
}
