using api.Models.Common;
using FluentValidation;

namespace api.Services.Common.Validators.Entities;

public class BaseEntityValidator : AbstractValidator<BaseEntity>
{
    public BaseEntityValidator()
    {
        RuleFor(x => x.Id).NotNull().GreaterThan(0);
    }
}