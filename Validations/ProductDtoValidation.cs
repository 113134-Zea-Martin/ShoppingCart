using FluentValidation;
using WebApplication8.Dtos;

namespace WebApplication8.Validations
{
    public class ProductDtoValidation : AbstractValidator<ProductoDto>
    {
        public ProductDtoValidation()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("El campo Id no puede estar vacío.");

            RuleFor(x=> x.Name).NotEmpty().WithMessage("El casdasdasdao.");
        }

        private bool BeAValidGuid(Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
