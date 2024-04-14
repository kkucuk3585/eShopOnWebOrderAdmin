using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorShared.Models;

namespace BlazorShared.Interfaces;

public interface IOrderService
{
    //Task<CatalogItem> Create(CreateCatalogItemRequest catalogItem);
    //Task<CatalogItem> Edit(CatalogItem catalogItem);
    //Task<string> Delete(int id);
    //Task<CatalogItem> GetById(int id);
    //Task<List<CatalogItem>> ListPaged(int pageSize);
    Task<List<Orders>> GetOrders();
    Task<OrderDetail> GetOrdersById(int id);
    Task<Orders> UpdateOrder(Orders order);
}
