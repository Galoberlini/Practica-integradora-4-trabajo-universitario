using Microsoft.AspNetCore.Mvc;
using Practica_Integradora_4_trabajo_universitario.Models.DTOs.Requests;
using Practica_Integradora_4_trabajo_universitario.Services.Interfaces;

namespace Practica_Integradora_4_trabajo_universitario.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAllProducts());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _service.GetProductById(id);
        if (product == null) return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create(ProductForCreateDto dto)
    {
        var created = _service.CreateProduct(dto);
        if (created == null) return Conflict("Ya existe un producto con ese nombre.");

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, ProductForUpdateDto dto)
    {
        if (_service.GetProductById(id) == null) return NotFound();

        _service.UpdateProduct(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (_service.GetProductById(id) == null) return NotFound();

        _service.DeleteProduct(id);
        return NoContent();
    }

    [HttpGet("search")]
    public IActionResult Search([FromQuery] string name)
    {
        return Ok(_service.SearchProductsByName(name));
    }

    [HttpGet("stats")]
    public IActionResult GetStats()
    {
        return Ok(_service.GetStats());
    }
}