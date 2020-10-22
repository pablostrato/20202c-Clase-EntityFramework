using System;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    internal class ProductoMetadata
    {
        [Required]
        public string Nombre { get; set; }

        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public Nullable<decimal> Precio { get; set; }
    }
}