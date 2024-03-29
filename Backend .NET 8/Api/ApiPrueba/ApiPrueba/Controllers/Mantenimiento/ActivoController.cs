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
    public class ActivoController : ControllerBase
    {
        public ActivoService activoService;

        public ActivoController(ActivoService activoService)
        {
            this.activoService = activoService;
        }

        [HttpGet]
        public ActionResult<List<Activo>> GetAllActivos()
        {
            return activoService.GetAllActivos();
        }

        [HttpGet("{id}")]
        public ActionResult<List<Activo>> GetActivoById(String id)
        {
            return activoService.GetActivoById(id);
        }
        [HttpGet("getbynombre/{nombre}")]
        public ActionResult<List<Activo>> GetActivoByNombre(String nombre)
        {
            return activoService.GetActivoByNombre(nombre);
        }

        [HttpPost]
        public ActionResult AddActivo(Activo activo)
        {
            activoService.AddActivo(activo);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateActivo(Activo activo)
        {
            activoService.UpdateActivo(activo.idactivo, activo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteActivo(String id)
        {
            activoService.DeleteActivo(id);
            return Ok();
        }
    }
}
