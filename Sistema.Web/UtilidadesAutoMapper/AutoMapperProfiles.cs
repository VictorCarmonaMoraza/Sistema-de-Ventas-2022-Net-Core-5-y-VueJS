using AutoMapper;
using Sistema.Entidades;
using Sistema.Web.Models.Almacen.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.UtilidadesAutoMapper
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            //Tenemos desde donde vamos a mappear que sera la fuente y el destino
            CreateMap<Categoria, CategoriaDTO>().
                ForMember(dest => dest.NombreCereal, opt => opt.MapFrom(src => src.nombre != null ? src.nombre : string.Empty)).
                ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.descripcion != null ? src.descripcion : string.Empty)).
                ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.condicion != null ? src.condicion : false));
        }
    }
       
}
