using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using Api.UseCases.Users.GetUsers;

namespace Api.Controllers.v1.Users.Transport.GetUsers
{
    [ExcludeFromCodeCoverage]
    public class GetUsersMapProfile : Profile
    {
        public GetUsersMapProfile()
        {
            CreateMap<GetUsersRequest, GetUsersInput>();
            CreateMap<GetUsersOutput, GetUsersResponse>();
        } 
    }
}