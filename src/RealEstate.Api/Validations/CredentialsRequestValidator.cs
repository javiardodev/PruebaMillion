using FluentValidation;
using RealEstate.Api.Dtos.Security;

namespace RealEstate.Api.Validations;

/// <summary>
/// Validator class custom for CredentialsRequest object
/// </summary>
public class CredentialsRequestValidator : AbstractValidator<CredentialsRequest>
{
    /// <summary>
    /// Methos about rules descrirption
    /// </summary>
    public CredentialsRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotNull().NotEmpty().WithMessage("El campo username es requerido.")
            .Length(3, 20).WithMessage("El username debe tener entre 3 y 20 caracteres.");

        RuleFor(x => x.Password)
            .NotNull().NotEmpty().WithMessage("El campo username es requerido.");
    }
}