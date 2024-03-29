

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
    public class AsientoController : ControllerBase
    {
        public AsientoService asientoService;

        public AsientoController(AsientoService asientoService)
        {
            this.asientoService = asientoService;
        }

        [HttpGet]
        public ActionResult<List<Asiento>> GetAllAsiento()
        {
            return asientoService.GetAllAsiento();
        }

        [HttpGet("{id}")]
        public ActionResult<List<Asiento>> GetAsientoById(String id)
        {
            return asientoService.GetAsientoById(id);
        }
        [HttpGet("getbyfecha/{fechainicio}/{fechafin}")]
        public ActionResult<List<Asiento>> GetAsientoByFecha(DateTime fechainicio, DateTime fechafin)
        {
            return asientoService.GetAsientoByFecha(fechainicio,fechafin);
        }
  
        [HttpPost]
        public ActionResult AddTipoCuenta(Asiento asiento)
        {
            asientoService.AddAsiento(asiento);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateTipoCuenta(Asiento asiento)
        {
            asientoService.UpdateAsiento(asiento.idasiento, asiento);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTipoCuenta(String id)
        {
            asientoService.DeleteAsiento(id);
            return Ok();
        }
    }
}
