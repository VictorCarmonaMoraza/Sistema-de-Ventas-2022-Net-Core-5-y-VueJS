using Microsoft.AspNetCore.Mvc;
using Sistema.Web.Interfaces;
using System.Web.Http;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using System.Net;

namespace Sistema.Web.Controllers
{
    public partial class CategoriasController : ApiController
    {
        // GET: api/Categorias/Listar
        [HttpGet]
        [System.Web.Http.Route("Listar")]
        public ActionResult Listar()
        {
            return ((ICategoriaController)this).Listar();
        }
    }
}
