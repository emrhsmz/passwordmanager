using AutoMapper;
using passwordmanager.Entities.Concrete;
using passwordmanager.WebUI.Models;

namespace passwordmanager.WebUI.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Platform, PlatformModel>();
            CreateMap<PlatformModel, Platform>();
            
            CreateMap<AccountProperty, AccountPropertyModel>();
            CreateMap<AccountPropertyModel, AccountProperty>();
            
            CreateMap<Safe, SafeModel>();
            CreateMap<SafeModel, Safe>();
            
            CreateMap<SystemType, SystemTypeModel>();
            CreateMap<SystemTypeModel, SystemType>();
        }
    }
}
