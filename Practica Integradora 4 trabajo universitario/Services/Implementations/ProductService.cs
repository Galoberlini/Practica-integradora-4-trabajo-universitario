using Practica_Integradora_4_trabajo_universitario.Entities;
using Practica_Integradora_4_trabajo_universitario.Models.DTOs.Requests;
using Practica_Integradora_4_trabajo_universitario.Models.DTOs.Responses;
using Practica_Integradora_4_trabajo_universitario.Repositories.Interfaces;
using Practica_Integradora_4_trabajo_universitario.Services.Interfaces;

namespace Practica_Integradora_4_trabajo_universitario.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public List<ProductForReadDto> GetAllProducts()
    {
        return _repository.GetAllProducts()
            .Select(ToReadDto)
            .ToList();
    }

    public ProductForReadDto? GetProductById(int id)
    {
        var product = _repository.GetProductById(id);
        return product == null ? null : ToReadDto(product);
    }

    public ProductForReadDto? CreateProduct(ProductForCreateDto dto)
    {
        var exists = _repository.GetAllProducts()
            .Any(p => p.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase));

        if (exists) return null;

        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price
        };

        _repository.AddProduct(product);
        return ToReadDto(product);
    }

    public void UpdateProduct(int id, ProductForUpdateDto dto)
    {
        var product = _repository.GetProductById(id);
        if (product == null) return;

        product.Name = dto.Name;
        product.Price = dto.Price;
        _repository.UpdateProduct(product);
    }

    public void DeleteProduct(int id)
    {
        var product = _repository.GetProductById(id);
        if (product == null) return;

        _repository.DeleteProduct(product);
    }

    private static ProductForReadDto ToReadDto(Product product)
    {
        return new ProductForReadDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }

    public List<ProductForReadDto> SearchProductsByName(string name)
    {
        return _repository.SearchProductsByName(name)
            .Select(ToReadDto)
            .ToList();
    }

    public ProductStatsDto GetStats()
    {
        var products = _repository.GetAllProducts();

        if (products.Count == 0)
        {
            return new ProductStatsDto
            {
                Total = 0,
                AveragePrice = 0,
                MostExpensiveName = string.Empty
            };
        }

        var mostExpensive = products.OrderByDescending(p => p.Price).First();

        return new ProductStatsDto
        {
            Total = products.Count,
            AveragePrice = products.Average(p => p.Price),
            MostExpensiveName = mostExpensive.Name
        };
    }

}