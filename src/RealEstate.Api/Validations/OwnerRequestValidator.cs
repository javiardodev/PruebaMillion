using FluentValidation;
using RealEstate.Api.Dtos.Owner;

namespace RealEstate.Api.Validations
{
    /// <summary>
    /// 
    /// </summary>
    public class OwnerRequestValidator : AbstractValidator<OwnerRequest>
    {
        /// <summary>
        /// Methos about rules descrirption
        /// </summary>
        public OwnerRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty().WithMessage("El nombre es requerido.")
                .Length(3, 20).WithMessage("El nombre debe tener entre 3 y 20 caracteres.");

            RuleFor(x => x.Address)
                .NotNull().NotEmpty().WithMessage("La dirección es requerida.")
                .Matches(@"^[0-9a-zA-Z#°.\- ]+$").WithMessage("La dirección permite solo caracteres (# . - °).")
                .MaximumLength(50).WithMessage("La dirección no debe superar los 50 caracteres.");

            RuleFor(owner => owner.Photo)
                .NotEmpty().WithMessage("The Photo field is required.")
                .Must(IsValidImageExtension)
                .WithMessage("The Photo must have a valid image extension (.jpg, .jpeg, .png, etc.).")
                .When(owner => !string.IsNullOrEmpty(owner.Photo));

            RuleFor(owner => owner.Birthday)
                .LessThan(DateTime.Now).WithMessage("La fecha de cumpleaños debe ser en el pasado.")
                .When(owner => owner.Birthday.HasValue);
        }

        private bool IsValidImageExtension(string? photoPath)
        {
            if (string.IsNullOrEmpty(photoPath)) return false;

            var validExtensions = new string[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tiff", ".webp" };
            var fileExtension = Path.GetExtension(photoPath).ToLower();
            return validExtensions.Contains(fileExtension);
        }
    }
}