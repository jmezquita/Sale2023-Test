using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities
{

    /// <summary>
    /// Contry model class
    /// </summary>
    public class Country : EntityBase
    {
        /// <summary>
        /// Country Name
        /// </summary>

        [Display(Name = "Pais")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede tener mas de {1} caractéres")]
        public string? Name { get; set; }
    }
}
