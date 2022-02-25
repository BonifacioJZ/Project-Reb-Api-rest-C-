using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Dto.Categories;
namespace WebApi.Controllers;


[ApiController]
[Route("[controller]")]
public class CategoryController:ControllerBase{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService){
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult> Index() => Ok(await _categoryService.GetAll());

    [HttpGet("id")]
    public async Task<ActionResult> Show(Guid id) => Ok(await _categoryService.GetByCategory(id));

    [HttpPost]
    public async Task<ActionResult> Store([FromBody]CategoriesDto category){
        var newCategory = await _categoryService.Create(category);
        return Created("Created",new{
            newCategory
        });
    }
    [HttpPut("id")]
    public async Task<ActionResult> Update([FromBody]CategoriesDto category, Guid id){
        var updateCategory = await _categoryService.Update(category, id);
        return Ok(updateCategory);
    }
    [HttpDelete("id")]
    public async Task<ActionResult> Delete(Guid id) => Ok(await _categoryService.Delete(id));

}