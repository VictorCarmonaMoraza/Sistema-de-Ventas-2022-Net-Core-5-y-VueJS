using Microsoft.EntityFrameworkCore;
using Sistema.Datos.MappingConBBDD.AlmacenMapping;
using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Datos
{
    public class DbContextSistema : DbContext
    {
        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
        }

        public DbSet<Categoria> Categorias { get; set; }
    }
}
