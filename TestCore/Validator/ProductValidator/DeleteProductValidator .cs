using FluentValidation;
using TestCore.Dto.Request;
using TestCore.Interfaces;

namespace TestCore.Validator.ProductValidator
{
    public class DeleteProductValidator : AbstractValidator<ProductRequest>
    {
        private readonly IProductInterface _productInterface;
        public DeleteProductValidator(IProductInterface productInterface) {
                
            _productInterface = productInterface;

            RuleFor(d => d.Id).NotEmpty().WithMessage("El Id es requerido")
                .MustAsync(ExistProduct).WithMessage("El Id introducido no existe");
           
        }
        private async Task<bool> ExistProduct(int id, CancellationToken cancellationToken)
        {
           var product = await _productInterface.GetProductById(id);

            if (product == null) return false;

            return true;
        }
    }
}
