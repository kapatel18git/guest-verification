using AutoMapper;
using GuestVerification.Core.DTOs;
using GuestVerification.Core.Entities;

namespace GuestVerification.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GuestWhitelist, WhitelistEntryDto>();
            CreateMap<WhitelistRequestDto, GuestWhitelist>();
        }
    }
}
