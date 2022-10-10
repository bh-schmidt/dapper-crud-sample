using FluentValidation;
using System.Diagnostics.CodeAnalysis;

namespace Api.UseCases.Users.CreateNew
{
    [ExcludeFromCodeCoverage]
    public class CreateNewInputValidation : AbstractValidator<CreateNewInput>
    {
        public CreateNewInputValidation()
        {
        }
    }
}
