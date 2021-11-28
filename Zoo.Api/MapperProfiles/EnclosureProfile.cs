using AutoMapper;
using Zoo.Core.Models;

namespace Zoo.Api.MapperProfiles
{
    public class EnclosureProfile : Profile
    {
        public EnclosureProfile()
        {
            CreateMap<ViewModels.Enclosure.Create.RequestViewModel, Enclosure>();

            CreateMap<ViewModels.Enclosure.Update.RequestViewModel, Enclosure>();
        }
    }
}