using AutoMapper;
using Zoo.Core.Models;

namespace Zoo.Api.MapperProfiles
{
    public class ZebraProfile : Profile
    {
        public ZebraProfile()
        {
            CreateMap<ViewModels.Zebra.Create.RequestViewModel, Zebra>();

            CreateMap<ViewModels.Zebra.Update.RequestViewModel, Zebra>();
        }
    }
}