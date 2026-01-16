
using StoreFrontUK.GlobalObjects.PickService.Responses;
using StoreFrontUK.Services.PickService.Requests;

namespace StoreFrontUK.Services.PickService;

public interface IPickService
{
    Task<PickOrderResponse> PickAsync(PickOrderRequest pickOrderRequest);

    Task PickExternalAsync(PickOrderRequest pickOrderRequest, PickOrderResponse pickOrderResponse);
}