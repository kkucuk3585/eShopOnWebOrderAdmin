using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using Microsoft.Extensions.Logging;


namespace BlazorAdmin.Services;

public class OrderService : IOrderService
{
    private readonly HttpService _httpService;
    private readonly ILogger<CatalogItemService> _logger;



    public OrderService(HttpService httpService, 
        ILogger<CatalogItemService> logger)
    {
        _httpService = httpService;
        _logger = logger;
    }

    public async Task<List<Orders>> GetOrders()
    {
        _logger.LogInformation("Fetching orders from API.");
                
        return (await _httpService.HttpGet<GetAllOrdersResponse>($"orders")).OrderList;
    }

    public async Task<OrderDetail> GetOrdersById(int id)
    {
        _logger.LogInformation("Fetching selected order details from API.");

        return (await _httpService.HttpGet<GetOrdersByIdResponse>($"orders/{id}")).SelectedOrder;
    }

    public async Task<Orders> UpdateOrder(Orders order)
    {
        return await _httpService.HttpPut<Orders>("orders", order);
    }
}
