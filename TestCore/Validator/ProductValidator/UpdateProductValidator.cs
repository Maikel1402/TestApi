using FluentValidation;
using TestCore.Dto.Request;
using TestCore.Interfaces;

namespace TestCore.Validator.ProductValidator
{
    public class UpdateProductValidator : AbstractValidator<ProductRequest>
    {
        private readonly IProductService _productInterface;
        public UpdateProductValidator(IProductService productInterface) {
                
            _productInterface = productInterface;

            RuleFor(d => d.Id).NotEmpty().WithMessage("El Id es requerido")
                .MustAsync(ExistProduct).WithMessage("El Id introducido no existe");
            RuleFor(d=> d.Name).NotEmpty().WithMessage("El Nombre es requerido");            
            RuleFor(d=> d.Description).NotEmpty().WithMessage("La descripcion es requerida");
            RuleFor(d=> d.NetPrice).GreaterThan(0).WithMessage("El precio es requerido y mayor a 0");
        }
        private async Task<bool> ExistProduct(int id, CancellationToken cancellationToken)
        {
           var product = await _productInterface.GetProductById(id);

            if (product == null) return false;

            return true;
        }
    }
}
