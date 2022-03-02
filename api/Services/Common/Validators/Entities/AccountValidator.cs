using api.Models.Entities;
using api.Repositories.Common.Interfaces;
using FluentValidation;

namespace api.Services.Common.Validators.Entities;

public class AccountValidator : AbstractValidator<Account>
{
    public AccountValidator(IAccountRepository? accountRepository)
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.PostalAddress).SetValidator(new AddressValidator());

        RuleFor(x => x.Email)
            .NotNull()
            .EmailAddress()
            .MustAsync(async (email, ct) =>
            {
                if (accountRepository is null) { return true; }

                return !(await accountRepository
                    .GetAll())
                    .Select(x => x.Email)
                    .Contains(email);
            });
    }
}