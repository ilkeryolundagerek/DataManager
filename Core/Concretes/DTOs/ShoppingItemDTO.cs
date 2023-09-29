using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs
{
    public class ShoppingItemDTO
    {
        public int ProductID { get; set; }
        public string ProductNumber { get; set; }
        public string Name { get; set; }
        public decimal ListPrice { get; set; }
        public byte[]? ThumbNailPhoto { get; set; }
        public int Quantity { get; set; }
    }

    public class ShoppingCartDTO
    {
        public string Id { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalDue { get; set; }
    }
}
