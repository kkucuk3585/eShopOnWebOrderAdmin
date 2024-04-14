using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Interfaces;

public interface IOrderService
{
    Task<List<Orders>> GetOrders();
    Task<OrderDetail> GetOrdersById(int id);
    Task<Orders> UpdateOrder(Orders order);
}
