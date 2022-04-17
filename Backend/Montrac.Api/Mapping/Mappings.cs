using AutoMapper;
using Montrac.api.DataObjects.User;
using Montrac.Domain.DataObjects;
using Montrac.Domain.DataObjects.Invitation;
using Montrac.Domain.DataObjects.Screenshot;
using Montrac.Domain.DataObjects.Url;
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
            CreateMap<GuestUsers, User>();
            CreateMap<NewUrl, Url>();
            CreateMap<Url, NewUrl>();
            CreateMap<UrlReceived, Url>();
            CreateMap<NewProgram, Domain.Models.Program>();
            CreateMap<Domain.Models.Program, NewProgram>();
            CreateMap<NewInvitation, InvitationRequest>();
            CreateMap<InvitationRequest, NewInvitation>();
            CreateMap<CreateNewInvitation, InvitationRequest>();
            CreateMap<RegisterArea, Area>();
            CreateMap<NewArea, Area>();
            CreateMap<Area, NewArea>();
            CreateMap<NewScreenshot, Screenshot>();
            CreateMap<Screenshot, NewScreenshot>();
            CreateMap<NewUrlReceived, UrlReceived>();
            CreateMap<UrlReceived, NewUrlReceived>();
        }
    }
}