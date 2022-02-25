using Domain.Dto.Products;
using FluentValidation;

namespace Application.Validations
{
    public class ProductValidations:AbstractValidator<ProductDto>{
        public ProductValidations(){
            RuleFor(x=>x.Name)
            .NotEmpty()
            .MaximumLength(150);
            RuleFor(x=>x.Description)
            .MaximumLength(500);
            RuleFor(x=>x.CategoryId)
            .NotEmpty();
        }

    }
}