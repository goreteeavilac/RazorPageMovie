using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RazorPageMovie.Models
{
    public class Movie
    {
        //Declaración de variables que vamos a usar en el sistema
        public int Id { get; set; }
        [StringLength(60,MinimumLength = 3)]
        [Required]
        public string? Title { get; set; } //? el string puede aceptar nulos
        [Display(Name = "Release Date")] //Nombre en la tabla en la página
        [DataType(DataType.Date)] //Etiqueta para una variable llamada ReleaseDate que tome en cuenta que sera de tipo date
        public DateTime ReleaseDate { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(39)]
        public string? Gender { get; set; }
        [Range (1,100)]
        [DataType (DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")] //Las etiquetas deben ir arriba de las variables
        public decimal Price { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s]*$")] //Agregar números y letras
        [StringLength (5)]
        [Required]
        public string? Rating { get; set; }
    }
}
