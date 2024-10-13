using FluentValidation;
using TestCore.Dto.Request;

namespace TestCore.Validator.ProductValidator
{
    public class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductValidator() { 
        
            RuleFor(d=> d.Name).NotEmpty().WithMessage("El Nombre es requerido");
            RuleFor(d=> d.Description).NotEmpty().WithMessage("La descripcion es requerida");
            RuleFor(d=> d.NetPrice).GreaterThan(0).WithMessage("El precio es requerido y mayor a 0");
        }
    }
}
