using AutoMapper;
using Montrac.api.DataObjects.User;
using Montrac.Domain.Models;

namespace Montrac.Api.Mapping
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<RegisterUser, User>();
            CreateMap<BasicUserView, User>();
            CreateMap<User, BasicUserView>();
        }
    }
}