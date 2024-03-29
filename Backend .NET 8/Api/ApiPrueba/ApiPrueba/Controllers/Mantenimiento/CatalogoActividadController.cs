using ApiPrueba.Model.Mantenimiento;
using ApiPrueba.Services.Mantenimiento;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiPrueba.Controllers.Mantenimiento
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoActividadController : ControllerBase
    {
        public CatalogoActividadService catalogoActividadService;

        public CatalogoActividadController(CatalogoActividadService catalogoActividadService)
        {
            this.catalogoActividadService = catalogoActividadService;
        }

        [HttpGet]
        public ActionResult<List<CatalogoActividad>> GetAllCatalogoActividades()
        {
            return catalogoActividadService.GetAllCatalogoActividades();
        }

        [HttpGet("{id}")]
        public ActionResult<CatalogoActividad> GetCatalogoActividadServiceById(String id)
        {
            return catalogoActividadService.GetCatalogoActividadById(id).First();
        }

        [HttpGet("getbynombre/{nombre}")]
        public ActionResult<List<CatalogoActividad>> GetCatalogoActividadByNombre(String nombre)
        {
            return catalogoActividadService.GetCatalogoActividadByNombre(nombre);
        }

        [HttpPost]
        public ActionResult AddCatalogoActividadService(CatalogoActividad catalogoActividad)
        {
            catalogoActividadService.AddCatalogoActividad(catalogoActividad);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateCatalogoActividadService(CatalogoActividad catalogoActividad)
        {
            catalogoActividadService.UpdateCatalogoActividad(catalogoActividad.idcatactividad, catalogoActividad);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCatalogoActividadService(String id)
        {
            catalogoActividadService.DeleteCatalogoActividad(id);
            return Ok();
        }

    }
}
