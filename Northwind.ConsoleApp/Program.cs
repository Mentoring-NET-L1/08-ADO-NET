using System;
using System.Collections.Generic;
using System.Configuration;
using Northwind.Dal.Interfaces;
using Northwind.Dal.Models;
using Northwind.Dal.Repositories;

namespace Northwind.ConsoleApp
{
    internal class Program
    {
        private static void Main()
        {
            try
            {
                var connectionSettings = GetConnectionSettings("Northwind");
                IOrderRepository repository =
                    new SqlOrderRepository(connectionSettings.ConnectionString, connectionSettings.ProviderName);

                foreach (var order in repository.Get())
                {
                    Console.WriteLine($"{order.OrderId}, {order.OrderDate}");
                }

                var concretOrder = repository.GetDetailedInfo(10282);
                Console.WriteLine($"{concretOrder.OrderId}, {concretOrder.OrderDate}");
                foreach (var detail in concretOrder.Details)
                {
                    Console.WriteLine($"{detail.Product.Discontinued}, {detail.UnitPrice}, {detail.Quantity}");
                }

                var addedOrder = repository.Add(new Order() {ShipCity = "Minsk"});

                addedOrder.ShipCountry = "Belarus";
                addedOrder = repository.Update(addedOrder);

                repository.StartProgress(addedOrder.OrderId, DateTime.Now);
                repository.Close(addedOrder.OrderId, DateTime.Now);

                repository.Delete(addedOrder.OrderId);

                foreach (var customerOrder in repository.CustOrderHist("ALFKI"))
                {
                    Console.WriteLine($"{customerOrder.ProductName}, {customerOrder.Total}");
                }

                foreach (var customerOrder in repository.CustOrdersDetail(10282))
                {
                    Console.WriteLine($"{customerOrder.ProductName}, {customerOrder.Quantity}, {customerOrder.ExtendedPrice}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadLine();
        }

        private static ConnectionStringSettings GetConnectionSettings(string name)
        {
            var settings = ConfigurationManager.ConnectionStrings;

            if (settings != null)
            {
                foreach (ConnectionStringSettings connectionSettings in settings)
                {
                    if (connectionSettings.Name == name)
                        return connectionSettings;
                }
            }

            throw new KeyNotFoundException($"Can't find connection string with name \"{name}\".");
        }
    }
}
