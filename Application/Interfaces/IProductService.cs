using Domain.Dto.Products;


namespace Application.Interfaces;

public interface IProductService{
    Task<ICollection<ProductDto>> GetAll();
    Task<ProductDetailsDto> GetById(Guid productId);
    Task<ProductDto> Create(ProductDto product);
    Task<ProductDto> Update(ProductDto product,Guid productId);
    Task<int> Delete(Guid productId);
}