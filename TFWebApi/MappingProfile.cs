using AutoMapper;
using TFWebApi.Data.Model;
using TFWebApi.Data.Model.DTO;

namespace TFWebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Lector, LectorCreateDTO>().ReverseMap();
            CreateMap<Lector, LectorUpdateDTO>().ReverseMap();
        }
    }
}
