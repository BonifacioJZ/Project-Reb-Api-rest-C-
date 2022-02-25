using FluentValidation;
using Domain.Dto.Categories;
namespace Application.Validations;

public class CategoryValidation:AbstractValidator<CategoriesDto>{ 
    public CategoryValidation(){
        RuleFor(x=>x.Name)
        .NotEmpty()
        .MinimumLength(1)
        .MaximumLength(100);
        RuleFor(x=>x.Description)
        .MaximumLength(500);

    }
}