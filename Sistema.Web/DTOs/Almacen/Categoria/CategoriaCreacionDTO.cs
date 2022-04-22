using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.DTOs.Almacen.Categoria
{
    public class CategoriaCreacionDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe tener mas de 50 caracteres, ni menos de 3")]
        public string NombreCereal { get; set; }
        [StringLength(256)]
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }
    }
}
