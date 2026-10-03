using Practica_Integradora_4_trabajo_universitario.Models.DTOs.Requests;
using Practica_Integradora_4_trabajo_universitario.Models.DTOs.Responses;

namespace Practica_Integradora_4_trabajo_universitario.Services.Interfaces;

public interface IProductService
{
    List<ProductForReadDto> GetAllProducts();
    ProductForReadDto? GetProductById(int id);
    ProductForReadDto? CreateProduct(ProductForCreateDto dto);
    void UpdateProduct(int id, ProductForUpdateDto dto);
    void DeleteProduct(int id);
    List<ProductForReadDto> SearchProductsByName(string name);
    ProductStatsDto GetStats();
}