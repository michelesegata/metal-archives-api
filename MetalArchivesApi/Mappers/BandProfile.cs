using AutoMapper;
using MetalArchivesApi.Dto;
using MetalArchivesApi.Model;

namespace MetalArchivesApi.Mappers;

public class BandProfile : Profile
{
    public BandProfile()
    {
        CreateMap<Band, BandDto>();
    }
}