using System;
using System.Collections.Generic;
using System.Text;

namespace AzureServiceBusDemo.QueueDemo.Model
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
