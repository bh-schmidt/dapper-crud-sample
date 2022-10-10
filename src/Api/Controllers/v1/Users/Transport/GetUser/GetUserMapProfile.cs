using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using Api.UseCases.Users.GetUser;

namespace Api.Controllers.v1.Users.Transport.GetUser
{
    [ExcludeFromCodeCoverage]
    public class GetUserMapProfile : Profile
    {
        public GetUserMapProfile()
        {
            CreateMap<GetUserOutput, GetUserResponse>();
        } 
    }
}