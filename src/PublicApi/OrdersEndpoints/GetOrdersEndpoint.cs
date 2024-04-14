
using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.eShopWeb.PublicApi.OrdersEndpoints;
using MinimalApi.Endpoint;
using Microsoft.eShopWeb.ApplicationCore.Specifications;
using Azure.Core;
using System.Threading;


/// <summary>
/// Get all Orders
/// </summary>
public class GetOrdersEndpoint : IEndpoint<IResult, IRepository<Order>>
{
    private readonly IUriComposer _uriComposer;
    private readonly IMapper _mapper;

    public GetOrdersEndpoint(IUriComposer uriComposer, IMapper mapper)
    {
        _uriComposer = uriComposer;
        _mapper = mapper;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/orders",
            async (IRepository<Order> itemRepository) =>
            {
                return await HandleAsync(itemRepository);
            })
            .Produces<GetOrdersResponse>()
            .WithTags("OrdersEndpoints");
    }

    public async Task<IResult> HandleAsync(IRepository<Order> itemRepository)
    {
        var specification = new AllOrdersSpecification();
        var items = await itemRepository.ListAsync(specification, new CancellationToken());

        var response = new GetOrdersResponse();

        //var items = await itemRepository.ListAsync();

        //response.OrderList.AddRange(items.Select(_mapper.Map<OrdersDto>));
        //items.Where(o => o.BuyerId == "qq").Include(o => o.OrderItems);

        response.OrderList.AddRange(items.Select(o => new OrdersDto
        {
            Id = o.Id,
            OrderDate = o.OrderDate,
            BuyerId = o.BuyerId,
            Status = o.Status,
            Total = o.Total()
        }));

        return Results.Ok(response);
    }
}
