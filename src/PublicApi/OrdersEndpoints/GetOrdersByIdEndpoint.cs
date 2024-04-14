using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MinimalApi.Endpoint;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using System.Threading;
using BlazorShared.Models;
using System.Linq;

namespace Microsoft.eShopWeb.PublicApi.OrdersEndpoints;

/// <summary>
/// Get an Order by Id
/// </summary>
public class GetOrdersByIdEndpoint : IEndpoint<IResult, GetOrdersByIdRequest, IRepository<Order>>
{
    private readonly IUriComposer _uriComposer;

    public GetOrdersByIdEndpoint(IUriComposer uriComposer)
    {
        _uriComposer = uriComposer;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/orders/{orderId}",
            async (int orderId, IRepository<Order> itemRepository) =>
            {
                return await HandleAsync(new GetOrdersByIdRequest(orderId), itemRepository);
            })
            .Produces<GetOrdersByIdResponse>()
            .WithTags("OrdersEndpoints");
    }

    public async Task<IResult> HandleAsync(GetOrdersByIdRequest request, IRepository<Order> itemRepository)
    {
        var specification = new OrderWithItemsByIdSpec(request.OrderId);
        var response = new GetOrdersByIdResponse(request.CorrelationId());

        var item = await itemRepository.FirstOrDefaultAsync(specification, new CancellationToken());
        if (item is null)
            return Results.NotFound();

        response.SelectedOrder = new OrderDetailDto
        {
            Id = item.Id,
            OrderDate = item.OrderDate,
            Status = item.Status,
            BuyerId = item.BuyerId,
            Total = item.Total(),            
            OrderItems = item.OrderItems.Select(oi => new OrderItemDto
            { 
                ProductName = oi.ItemOrdered.ProductName,
                UnitPrice = oi.UnitPrice,
                Units = oi.Units,
                PictureUrl = oi.ItemOrdered.PictureUri
            }).ToList()
        };

        return Results.Ok(response);
    }
}
