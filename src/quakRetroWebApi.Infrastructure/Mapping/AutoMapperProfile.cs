using AutoMapper;
using quakRetroWebApi.Core.Dtos.Users;
using quakRetroWebApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quakRetroWebApi.Infrastructure.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserEntity, UserDto>()
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))

           .ForMember(dest => dest.UserWallet, opt => opt.MapFrom(src => 
                new UserWalletDto() { 
                    Credits = src.Credits,
                    Pixels = src.Pixels,
                    Points = src.Points }))

           .ForMember(dest => dest.UserBadges, opt => opt.Ignore())

           .ForMember(dest => dest.UserSettings, opt => opt.MapFrom((src, dest, member, context) =>
                src.UserSettings != null ? context.Mapper.Map<UserSettingsDto>(src.UserSettings) : null));

        CreateMap<UserSettingsEntity, UserSettingsDto>();
    }
}
