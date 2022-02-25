using Application.Interfaces;
using AutoMapper;
using Domain.Dto.Products;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Services;

public class ProductService : IProductService
{
    private readonly RebContext _context;
    private readonly IMapper _mapper;
    public ProductService(RebContext context, IMapper mapper){
        _context = context;
        _mapper = mapper;
    }
    public async Task<ProductDto> Create(ProductDto product)
    {
        product.Id = Guid.NewGuid();
        var newProduct = _mapper.Map<Product>(product);
        _context.Products.Add(newProduct);
        var result = await _context.SaveChangesAsync();
        if(result == 0) throw new ArgumentException("Error in to created new product");
        return product;
    }

    public async Task<int> Delete(Guid productId)
    {
        var product = await _context.Products.FindAsync(productId);
        if (product == null) throw new ArgumentException("Product not Found");
        _context.Products.Remove(product);
        var result = await _context.SaveChangesAsync();
        if(result == 0) throw new ArgumentException("Error in to deleted product");
        return 1;
    }

    public async Task<ICollection<ProductDto>> GetAll()
    {
        var products_dto = _mapper.Map<ICollection<ProductDto>>(await _context.Products.ToListAsync());
        return products_dto;  
    }

    public async Task<ProductDetailsDto> GetById(Guid productId)
    {
        var productDetails = await _context.Products
        .Where(p => p.Id == productId)
        .Include(p => p.Category)
        .FirstOrDefaultAsync();
        var productDetailsDto = _mapper.Map<ProductDetailsDto>(productDetails);


        if(productDetails == null) throw new ArgumentException("Error in to find product");
        return productDetailsDto;
    }

    public async Task<ProductDto> Update(ProductDto product, Guid productId)
    {
        var actualProduct = await _context.Products.FindAsync(productId);
        if (actualProduct == null) throw new ArgumentException("Error in to find the product with id "+ productId);
        actualProduct.Name = product.Name ?? actualProduct.Name;
        actualProduct.Description = product.Description ?? actualProduct.Description;
        actualProduct.Price = product.Price;
        actualProduct.CategoryId = product.CategoryId;
        var result = await _context.SaveChangesAsync();
        if(result == 0) throw new ArgumentException("Error in to save the product");
        return product;
    }
}