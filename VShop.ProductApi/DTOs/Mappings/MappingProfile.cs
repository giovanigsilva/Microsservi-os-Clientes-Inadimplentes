using AutoMapper;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Titulo, TituloDTO>().ReverseMap();
        CreateMap<Cliente, ClienteDTO>()
            .ForMember(x=>x.TituloName, opt => opt.MapFrom(src => src.Titulo.Name));
    }
}

