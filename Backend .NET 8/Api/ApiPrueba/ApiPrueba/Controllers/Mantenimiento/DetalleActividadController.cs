using ApiPrueba.Model.Mantenimiento;
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
    public class DetalleActividadController : ControllerBase
    {
        public DetalleActividadService detalleActividadService;

        public DetalleActividadController(DetalleActividadService detalleActividadService)
        {
            this.detalleActividadService = detalleActividadService;
        }

        [HttpGet("getbyactivoid/{id}")]
        public ActionResult<List<DetalleActividad>> GetAllDetallesActividadesByActivoId(String id)
        {
            return detalleActividadService.GetAllDetallesActividadesByActivoId(id);
        }

        [HttpGet("getbyactividadid/{id}")]
        public ActionResult<List<DetalleActividad>> GetAllDetallesActividadesByActividadId(String id)
        {
            return detalleActividadService.GetAllDetallesActividadesByActividadId(id);
        }

        [HttpGet("getmaxcolfil")]
        public List<int> GetMaxColFilDetalleActividad()
        {
            return detalleActividadService.GetMaxColFilDetalleActividad();
        }

        [HttpGet("getfilaactivo")]
        public List<Activo> GetFilaActivo()
        {
            return detalleActividadService.GetFilaActivo();
        }

        [HttpGet("getcolumnadetalleaactividad/{idactivo}")]
        public List<string> GetColumnaDetalleaActividad(string idactivo)
        {
            return detalleActividadService.GetColumnaDetalleaActividad(idactivo);
        }

        [HttpPost]
        public ActionResult AddActivo(DetalleActividad detalleActividad)
        {
            detalleActividadService.AddDetalleActividad(detalleActividad);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateActivo(DetalleActividad detalleActividad)
        {
            detalleActividadService.UpdateDetalleActividad(detalleActividad.iddetalleactividad, detalleActividad);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteActivo(String id)
        {
            detalleActividadService.DeleteDetalleActividad(id);
            return Ok();
        }

        [HttpDelete("deleteidcabecera/{id}")]
        public ActionResult DeleteDetalleActividadPorCabecera(String id)
        {
            detalleActividadService.DeleteDetalleActividadPorCabecera(id);
            return Ok();
        }

    }
}
