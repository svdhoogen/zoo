using AutoMapper;
using Zoo.Core.Models;

namespace Zoo.Api.MapperProfiles
{
    public class GiraffeProfile : Profile
    {
        public GiraffeProfile()
        {
            CreateMap<ViewModels.Giraffe.Create.RequestViewModel, Giraffe>();

            CreateMap<ViewModels.Giraffe.Update.RequestViewModel, Giraffe>();
        }
    }
}