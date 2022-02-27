using api.Models.Common;
using FluentValidation;

namespace api.Models.Validators;

public class BaseEntityValidator : AbstractValidator<BaseEntity>
{
    public BaseEntityValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
    }
}