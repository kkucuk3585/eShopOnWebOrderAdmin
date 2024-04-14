using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using MinimalApi.Endpoint;

namespace Microsoft.eShopWeb.PublicApi.OrdersEndpoints;

/// <summary>
/// Updates a Catalog Item
/// </summary>
public class UpdateOrdersEndpoint : IEndpoint<IResult, UpdateOrdersRequest, IRepository<Order>>
{
    private readonly IUriComposer _uriComposer;

    public UpdateOrdersEndpoint(IUriComposer uriComposer)
    {
        _uriComposer = uriComposer;
    }

    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapPut("api/orders",
            [Authorize(Roles = BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
            async (UpdateOrdersRequest request, IRepository<Order> itemRepository) =>
            {
                return await HandleAsync(request, itemRepository);
            })
            .Produces<UpdateOrdersResponse>()
            .WithTags("OrdersEndpoints");
    }

    public async Task<IResult> HandleAsync(UpdateOrdersRequest request, IRepository<Order> itemRepository)
    {
        var response = new UpdateOrdersResponse(request.CorrelationId());

        var item = await itemRepository.GetByIdAsync(request.Id);
        if (item == null)
        {
            return Results.NotFound();
        }

        if (request.Status == 0)
            item.Status = 1;
        else
            item.Status = 0;

        await itemRepository.UpdateAsync(item);

        response.SelectedOrder = new OrdersDto
        {
            Status = item.Status
        };

        return Results.Ok(response);
    }
}
