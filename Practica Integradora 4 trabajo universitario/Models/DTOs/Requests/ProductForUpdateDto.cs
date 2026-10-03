using System.ComponentModel.DataAnnotations;

namespace Practica_Integradora_4_trabajo_universitario.Models.DTOs.Requests;

public class ProductForUpdateDto
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
    public string Name { get; set; } = string.Empty;

    [Range(typeof(decimal), "0.01", "999999999", ErrorMessage = "El precio debe ser mayor que cero.")]
    public decimal Price { get; set; }
}