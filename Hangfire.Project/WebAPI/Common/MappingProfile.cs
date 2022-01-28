using AutoMapper;
using Entity.Concrete;
using WebAPI.ViewModels;

namespace GarbageCollectSystemAPI.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Add configuration
            
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();
        }
    }
}