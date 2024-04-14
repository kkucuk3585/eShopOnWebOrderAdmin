using System.ComponentModel.DataAnnotations;

namespace Microsoft.eShopWeb.PublicApi.OrdersEndpoints;

public class UpdateOrdersRequest : BaseRequest
{
    public int Id { get; set; }

    [Range(0, 1)]
    public int Status { get; set; }
}
