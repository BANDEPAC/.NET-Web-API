using DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; } // Внешний ключ для связи с Product

        // Конструктор без параметров
        public OrderDTO()
        {
        }

        public OrderDTO(int orderId,int productId)
        {
            OrderId = orderId;
            ProductId = ProductId;
        }
    }
}
