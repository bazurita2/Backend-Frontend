

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
    public class CuentaController : ControllerBase
    {
        public CuentaService cuentaService;

        public CuentaController(CuentaService cuentaService)
        {
            this.cuentaService = cuentaService;
        }

        [HttpGet]
        public ActionResult<List<Cuenta>> GetAllCuenta()
        {
            return cuentaService.GetAllCuenta();
        }

        [HttpGet("{id}")]
        public ActionResult<List<Cuenta>> GetCuentaById(String id)
        {
            return cuentaService.GetCuentaById(id);
        }
        [HttpGet("getbynombre/{nombre}")]
        public ActionResult<List<Cuenta>> GetTipoCuentaByNombre(String nombre)
        {
            return cuentaService.GetCuentaByNombre(nombre);
        }

        [HttpPost]
        public ActionResult AddTipoCuenta(Cuenta tipo)
        {
            cuentaService.AddCuenta(tipo);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateCuenta(Cuenta cuenta)
        {
            cuentaService.UpdateCuenta(cuenta.idcuenta, cuenta);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTipoCuenta(String id)
        {
            cuentaService.DeleteCuenta(id);
            return Ok();
        }
    }
}
