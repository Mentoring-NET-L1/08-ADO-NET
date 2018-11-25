using System;
using System.Data.Common;
using Northwind.Dal.Helpers;
using Northwind.Dal.Models.ProcedureModels;

namespace Northwind.Dal.Models.Mappers
{
    internal static class DbDataReaderMappers
    {
        public static Order ToOrder(this DbDataReader reader)
        {
            return new Order
            {
                OrderId = reader.GetInt32("OrderID"),
                OrderDate = reader.GetNullable<DateTime>("OrderDate"),
                RequiredDate = reader.GetNullable<DateTime>("RequiredDate"),
                ShippedDate = reader.GetNullable<DateTime>("ShippedDate"),
                ShipName = reader.GetString("ShipName"),
                ShipAddress = reader.GetString("ShipAddress"),
                ShipCity = reader.GetString("ShipCity"),
                ShipRegion = reader.GetString("ShipRegion"),
                ShipPostalCode = reader.GetString("ShipPostalCode"),
                ShipCountry = reader.GetString("ShipCountry"),
            };
        }

        public static OrderDetail ToOrderDetail(this DbDataReader reader)
        {
            return new OrderDetail
            {
                UnitPrice = reader.GetDecimal("UnitPrice"),
                Quantity = reader.GetInt16("Quantity"),
                Discount = reader.GetFloat("Discount"),
            };
        }

        public static Product ToProduct(this DbDataReader reader)
        {
            return new Product
            {
                ProductId = reader.GetInt32("ProductId"),
                ProductName = reader.GetString("ProductName"),
                QuantityPerUnit = reader.GetString("QuantityPerUnit"),
                UnitPrice = reader.GetNullable<decimal>("UnitPrice"),
                UnitsInStock = reader.GetNullable<short>("UnitsInStock"),
                UnitsOnOrder = reader.GetNullable<short>("UnitsOnOrder"),
                ReorderLevel = reader.GetNullable<short>("ReorderLevel"),
                Discontinued = reader.GetBoolean("Discontinued"),
            };
        }

        public static CustomerOrder ToCustomerOrder(this DbDataReader reader)
        {
            return new CustomerOrder
            {
                ProductName = reader.GetString("ProductName"),
                Total = reader.GetInt32("Total"),
            };
        }

        public static CustomerOrderDetail ToCustomerOrderDetail(this DbDataReader reader)
        {
            return new CustomerOrderDetail
            {
                ProductName = reader.GetString("ProductName"),
                UnitPrice = reader.GetDecimal("UnitPrice"),
                Quantity = reader.GetInt16("Quantity"),
                Discount = reader.GetInt32("Discount"),
                ExtendedPrice = reader.GetDecimal("ExtendedPrice"),
            };
        }
    }
}
