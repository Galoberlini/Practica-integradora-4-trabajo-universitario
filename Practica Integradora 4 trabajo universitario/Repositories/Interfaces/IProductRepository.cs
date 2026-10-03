using Practica_Integradora_4_trabajo_universitario.Entities;

namespace Practica_Integradora_4_trabajo_universitario.Repositories.Interfaces;

public interface IProductRepository
{
    List<Product> GetAllProducts();
    Product? GetProductById(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    List<Product> SearchProductsByName(string name);
}