using Domain.Dto.Products;
using Domain.Models;

namespace Application.Interfaces;

public interface IProductService{
    Task<ICollection<Product>> GetAll();
    Task<ProductDto> GetById(Guid productId);
    Task<ProductDto> Create(ProductDto product);
    Task<ProductDto> Update(ProductDto product,Guid productId);
    Task<int> Delete(Guid productId);
}