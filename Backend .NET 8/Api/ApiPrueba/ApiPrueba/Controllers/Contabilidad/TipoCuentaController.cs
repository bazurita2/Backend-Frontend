

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
    public class TipoCuentaController : ControllerBase
    {
        public TipoCuentaService tipoCuentaService;

        public TipoCuentaController(TipoCuentaService tipoCuentaService)
        {
            this.tipoCuentaService = tipoCuentaService;
        }

        [HttpGet]
        public ActionResult<List<TipoCuenta>> GetAllTipoCuenta()
        {
            return tipoCuentaService.GetAllTipoCuenta();
        }

        [HttpGet("{id}")]
        public ActionResult<List<TipoCuenta>> GetTipoCuentaById(String id)
        {
            return tipoCuentaService.GetTipoCuentaById(id);
        }
        [HttpGet("getbynombre/{nombre}")]
        public ActionResult<List<TipoCuenta>> GetTipoCuentaByNombre(String nombre)
        {
            return tipoCuentaService.GetTipoCuentaByNombre(nombre);
        }

        [HttpPost]
        public ActionResult AddTipoCuenta(TipoCuenta tipo)
        {
            tipoCuentaService.AddTipoCuenta(tipo);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateTipoCuenta(TipoCuenta tipo)
        {
            tipoCuentaService.UpdateTipoCuenta(tipo.idtipocuenta, tipo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTipoCuenta(String id)
        {
            tipoCuentaService.DeleteTipoCuenta(id);
            return Ok();
        }
    }
}
