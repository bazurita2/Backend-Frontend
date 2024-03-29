using ApiPrueba.Model;
using ApiPrueba.Services.Mantenimiento;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Controllers.Mantenimiento
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        public ActividadService actividadService;

        public ActividadController(ActividadService actividadService)
        {
            this.actividadService = actividadService;
        }

        [HttpGet]
        public ActionResult<List<Actividad>> GetAllActivos()
        {
            return actividadService.GetAllActividades();
        }

        [HttpGet("getbyfecha/{fecha}")]
        public ActionResult<List<Actividad>> GetActividadesByFecha(DateTime fecha)
        {
            return actividadService.GetActividadesByFecha(fecha);
        }

        [HttpPost]
        public ActionResult AddActividad(Actividad actividad)
        {
            actividadService.AddActividad(actividad);
            return Ok();
        }

        [HttpGet("getlastactividad")]
        public ActionResult<Actividad> GetLastActividad()
        {
            return actividadService.GetLastActividad();
        }

        [HttpPut]
        public ActionResult UpdateActividad(Actividad actividad)
        {
            actividadService.UpdateActividad(actividad.idactividad, actividad);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteActividad(String id)
        {
            actividadService.DeleteActividad(id);
            return Ok();
        }
    }
}
