using AutoMapper;
using MetalArchivesApi.Dto;
using MetalArchivesApi.Model;

namespace MetalArchivesApi.Mappers;

public class BandMemberProfile : Profile
{
    public BandMemberProfile()
    {
        CreateMap<BandMember, BandMemberDto>();
    }
}