using FluentValidation;
using WebApplication8.Dtos;

namespace WebApplication8.Validations
{
    public class UpdateProductoDtoValidation : AbstractValidator<UpdateProductoDto>
    {
        public UpdateProductoDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El casdasdasdao.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Completar Datos")
                .MinimumLength(5).WithMessage("jladsjlsdadsajksad");
        }
    }
}
