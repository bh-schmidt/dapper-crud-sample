using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using Api.UseCases.Users.CreateNew;

namespace Api.Controllers.v1.Users.Transport.CreateNew
{
    [ExcludeFromCodeCoverage]
    public class CreateNewMapProfile : Profile
    {
        public CreateNewMapProfile()
        {
            CreateMap<CreateNewRequest, CreateNewInput>();
        } 
    }
}