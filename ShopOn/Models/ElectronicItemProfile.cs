using AutoMapper;

namespace ShopOn.Models
{
    public class ElectronicItemProfile : Profile
    {
        public ElectronicItemProfile()
        {
            this.CreateMap<ElectronicItem, ElectronicItemMini>();
        }
    }
}
