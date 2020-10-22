using System;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    internal class ProductoMetadata
    {
        [Required (ErrorMessage = "{0} es requerido")]
        public string Nombre { get; set; }

        [RegularExpression(@"^\d+\.?\d{0,2}$", ErrorMessage = "Formato incorrecto de {0}. N.NN")]
        [Range(0, double.PositiveInfinity, ErrorMessage = "El {0} debe ser entre 0 y 9999999999999999.99")]
        public Nullable<decimal> Precio { get; set; }
    }
}