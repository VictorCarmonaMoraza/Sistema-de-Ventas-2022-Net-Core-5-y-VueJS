using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Almacen.Categoria
{
    public class CategoriaDTO
    {
        public string NombreCereal { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }
    }
}
