

using ApiPrueba.Model;
using ApiPrueba.Model.Contabilidad;
using ApiPrueba.Services.Contabilidad;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiPrueba.Controllers.Contabilidad
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleAsientoController : ControllerBase
    {
        public DetalleAsientoService detalleasientoService;

        public DetalleAsientoController(DetalleAsientoService detalleasientoService)
        {
            this.detalleasientoService = detalleasientoService;
        }

        [HttpGet]
        public ActionResult<List<DetalleAsiento>> GetAllDetalleAsiento()
        {
            return detalleasientoService.GetAllDetalleAsiento();
        }

        [HttpGet("{id}")]
        public ActionResult<List<DetalleAsiento>> GetDetalleAsientoById(String id)
        {
            return detalleasientoService.GetDetalleAsientoById(id);
        }
        [HttpGet("getbyidcabecera/{idasiento}")]
        public ActionResult<List<DetalleAsiento>> GetDetalleAsientoByIdCabecera(String idasiento)
        {
            return detalleasientoService.GetDetalleAsientoByIdCabecera(idasiento);
        }

        [HttpPost]
        public ActionResult AddDetalleAsiento(DetalleAsiento detalleasiento)
        {
            detalleasientoService.AddDetalleAsiento(detalleasiento);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateTipoCuenta(DetalleAsiento detalleasiento)
        {
            detalleasientoService.UpdateDetalleAsiento(detalleasiento.iddetalle, detalleasiento);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDetalleAsiento(String id)
        {
            detalleasientoService.DeleteDetalleAsiento(id);
            return Ok();
        }
        [HttpDelete("deleteidcabecera/{idasiento}")]
        public ActionResult DeleteDetalleAsientoPorCabecera(String idasiento)
        {
            detalleasientoService.DeleteDetalleAsientoPorCabecera(idasiento);
            return Ok();
        }
    }
}
