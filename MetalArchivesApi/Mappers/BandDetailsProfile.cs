using AutoMapper;
using MetalArchivesApi.Dto;
using MetalArchivesApi.Model;

namespace MetalArchivesApi.Mappers;

public class BandDetailsProfile : Profile
{
    public BandDetailsProfile()
    {
        CreateMap<BandDetails, BandDetailsDto>();
    }
}