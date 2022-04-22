using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades;
using Sistema.Web.DTOs.Almacen.Categoria;
using Sistema.Web.Models.Almacen.Categoria;

namespace Sistema.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly DbContextSistema _context;
        private readonly IMapper mapper;

        public CategoriasController(DbContextSistema context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;

        }

        // GET: api/Categorias/Listar
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Listar()
        {
            var categorias= await _context.Categorias.ToListAsync();
            return mapper.Map<List<CategoriaDTO>>(categorias);
        }

        // GET: api/Categorias/Mostrar/1
        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> Mostrar([FromRoute] int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return mapper.Map<CategoriaDTO>(categoria);
        }

        // PUT: api/Categorias/5
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] CategoriaActualizarDTO modelCategoriaActualizarDTO)
        {
            //Validamos modelo segun los data anotation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Comprobamos que la categoria existe
            if (modelCategoriaActualizarDTO.idcategoria < 0)
            {
                return BadRequest();
            }

            //Si existe la  categoria me traigo el registro de base de datos
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.idcategoria == modelCategoriaActualizarDTO.idcategoria);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.nombre = modelCategoriaActualizarDTO.NombreCereal;
            categoria.descripcion = modelCategoriaActualizarDTO.Descripcion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Categorias/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<Categoria>> Crear([FromBody] CategoriaCreacionDTO modelCategoriaCreacionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Categoria modelCategoria = new Categoria
            {
                nombre = modelCategoriaCreacionDTO.NombreCereal,
                descripcion = modelCategoriaCreacionDTO.Descripcion,
                condicion = true
            };

            var categoria = mapper.Map<Categoria>(modelCategoria);

            _context.Add(categoria);

            try
            {
                //Guarda los cambios
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.idcategoria == id);
        }
    }
}
