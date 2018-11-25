using System;
using System.Collections.Generic;
using Northwind.Dal.Models;
using Northwind.Dal.Models.ProcedureModels;

namespace Northwind.Dal.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Get();

        Order GetDetailedInfo(int id);

        Order Add(Order newOrder);

        Order Update(Order order);

        void Delete(int id);

        void StartProgress(int id, DateTime orderDate);

        void Close(int id, DateTime shippedDate);

        IEnumerable<CustomerOrder> CustOrderHist(string customerId);

        IEnumerable<CustomerOrderDetail> CustOrdersDetail(int orderId);
    }
}
