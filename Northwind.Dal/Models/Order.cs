using System;
using System.Collections.Generic;
using Northwind.Dal.Models.Mappers;

namespace Northwind.Dal.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipRegion { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipCountry { get; set; }

        public List<OrderDetail> Details { get; set; }

        public OrderState State {
            get
            {
                if (OrderDate == null) return OrderState.New;
                if (ShippedDate == null) return OrderState.InProgress;
                return OrderState.Done;
            }
        }
    }
}