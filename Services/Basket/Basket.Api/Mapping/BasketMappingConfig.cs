using Basket.Api.Models.Entities;
using EventBus.Messages.Events;
using Mapster;

namespace Basket.Api.Mapping
{
    public class BasketMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<BasketCheckout, BasketCheckoutEvent>()
                .Map(dest => dest.Address, src => src.Address)
                .Map(dest => dest.Payment, src => src.Payment);
        }
    }
}
