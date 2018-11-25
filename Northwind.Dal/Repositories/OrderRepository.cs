using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Northwind.Dal.Helpers;
using Northwind.Dal.Interfaces;
using Northwind.Dal.Models;
using Northwind.Dal.Models.Mappers;
using Northwind.Dal.Models.ProcedureModels;
using Northwind.Dal.SqlScripts.OrderRepository.QueryProviders;

namespace Northwind.Dal.Repositories
{
    public abstract class OrderRepository : IOrderRepository
    {
        private readonly IOrderRepositoryQueryProvider _queryProvider;
        private readonly DbProviderFactory _providerFactory;
        private readonly string _connectionString;

        protected OrderRepository(IOrderRepositoryQueryProvider queryProvider, string connectionString, string provider)
        {
            _queryProvider = queryProvider;
            _providerFactory = DbProviderFactories.GetFactory(provider);
            _connectionString = connectionString;
        }

        public IEnumerable<Order> Get()
        {
            return ExecuteCommand((command) =>
            {
                command.CommandText = _queryProvider.GetOrders;

                var result = new List<Order>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.ToOrder());
                    }
                }

                return result;
            });
        }

        public Order GetDetailedInfo(int id)
        {
            return ExecuteCommand((command) =>
            {
                command.CommandText = _queryProvider.GetDetailedInfo;
                command.AddParameter("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) return null;

                    reader.Read();
                    var order = reader.ToOrder();

                    reader.NextResult();
                    order.Details = new List<OrderDetail>();
                    while (reader.Read())
                    {
                        var detail = reader.ToOrderDetail();
                        detail.Product = reader.ToProduct();

                        order.Details.Add(detail);
                    }

                    return order;
                }
            });
        }

        public Order Add(Order newOrder)
        {
            return ExecuteCommand((command) =>
            {
                command.CommandText = _queryProvider.AddOrder;
                command.AddParameter("@OrderDate", DbType.DateTime, newOrder.OrderDate);
                command.AddParameter("@RequiredDate", DbType.DateTime, newOrder.RequiredDate);
                command.AddParameter("@ShippedDate", DbType.DateTime, newOrder.ShippedDate);
                command.AddParameter("@ShipName", newOrder.ShipName);
                command.AddParameter("@ShipAddress", newOrder.ShipAddress);
                command.AddParameter("@ShipCity", newOrder.ShipCity);
                command.AddParameter("@ShipRegion", newOrder.ShipRegion);
                command.AddParameter("@ShipPostalCode", newOrder.ShipPostalCode);
                command.AddParameter("@ShipCountry", newOrder.ShipCountry);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) return null;

                    reader.Read();
                    return reader.ToOrder();
                }
            });
        }

        public Order Update(Order order)
        {
            if (order.State != OrderState.New)
                throw new ArgumentException("Order should has \"New\" status.", nameof(order));

            return ExecuteCommand((command) =>
            {
                command.CommandText = _queryProvider.UpdateOrder;
                command.AddParameter("@Id", order.OrderId);
                command.AddParameter("@RequiredDate", DbType.DateTime, order.RequiredDate);
                command.AddParameter("@ShipName", order.ShipName);
                command.AddParameter("@ShipAddress", order.ShipAddress);
                command.AddParameter("@ShipCity", order.ShipCity);
                command.AddParameter("@ShipRegion", order.ShipRegion);
                command.AddParameter("@ShipPostalCode", order.ShipPostalCode);
                command.AddParameter("@ShipCountry", order.ShipCountry);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows) return null;

                    reader.Read();
                    return reader.ToOrder();
                }
            });
        }

        public void Delete(int id)
        {
            ExecuteCommand((command) =>
            {
                command.CommandText = _queryProvider.DeleteOrder;
                command.AddParameter("@Id", id);

                return command.ExecuteNonQuery();
            });
        }

        public void StartProgress(int id, DateTime orderDate)
        {
            ExecuteCommand((command) =>
            {
                command.CommandText = _queryProvider.StartProgress;
                command.AddParameter("@Id", id);
                command.AddParameter("@OrderDate", orderDate);

                return command.ExecuteNonQuery();
            });
        }

        public void Close(int id, DateTime shippedDate)
        {
            ExecuteCommand((command) =>
            {
                command.CommandText = _queryProvider.CloseOrder;
                command.AddParameter("@Id", id);
                command.AddParameter("@ShippedDate", shippedDate);

                return command.ExecuteNonQuery();
            });
        }

        public IEnumerable<CustomerOrder> CustOrderHist(string customerId)
        {
            return ExecuteCommand((command) =>
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = _queryProvider.CustOrderHist;
                command.AddParameter("@CustomerID", customerId);

                var result = new List<CustomerOrder>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.ToCustomerOrder());
                    }
                }
                return result;
            });
        }

        public IEnumerable<CustomerOrderDetail> CustOrdersDetail(int orderId)
        {
            return ExecuteCommand((command) =>
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = _queryProvider.CustOrdersDetail;
                command.AddParameter("@OrderID", orderId);

                var result = new List<CustomerOrderDetail>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.ToCustomerOrderDetail());
                    }
                }
                return result;
            });
        }

        private TResult ExecuteCommand<TResult>(Func<DbCommand, TResult> execute)
        {
            TResult result;

            using (var connection = _providerFactory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    result = execute(command);
                }
            }

            return result;
        }
    }
}
