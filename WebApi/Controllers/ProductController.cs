using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Dto.Products;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase{
    private readonly IProductService _productService;
    public ProductController(IProductService productService){
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult> Index()=>Ok(await _productService.GetAll());

    [HttpGet("id")]
    public async Task<ActionResult> Show(Guid id)=> Ok(await _productService.GetById(id));

    [HttpPost]
    public async Task<ActionResult> Store([FromBody]ProductDto product){
        var newProduct = await _productService.Create(product);
        return Created("Created", new{
            newProduct
        });
    }
    [HttpPut("id")]
    public async Task<ActionResult> Update([FromBody]ProductDto product,Guid productId){
        var updatedProduct = await _productService.Update(product, productId);
        return Created("Updated",new{
            updatedProduct
        });

    }
    [HttpDelete("id")]
    public async Task<ActionResult> Delete(Guid productId){
        var deleted = await _productService.Delete(productId);
        return Ok(deleted);
    }

}