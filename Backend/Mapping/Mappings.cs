using AutoMapper;
using Montrac.API.DataObjects.User;
using Montrac.API.Domain.DataObjects;
using Montrac.API.Domain.DataObjects.Screenshot;
using Montrac.API.Domain.DataObjects.Url;
using Montrac.API.Domain.DataObjects.User;
using Montrac.API.Domain.Models;

namespace Montrac.API.Mapping
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<RegisterUser, User>();
            CreateMap<BasicUserView, User>();
            CreateMap<User, BasicUserView>();
            CreateMap<NewUrl, Url>();
            CreateMap<Url, NewUrl>();
            CreateMap<Domain.Models.Program, NewProgram>();
            CreateMap<NewProgram, Domain.Models.Program>();
            CreateMap<Screenshot, NewScreenshot>();
            CreateMap<NewScreenshot, Screenshot>();
        }
    }
}