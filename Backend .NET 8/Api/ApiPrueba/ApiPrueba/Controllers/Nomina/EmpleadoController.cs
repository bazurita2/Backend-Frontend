using ApiPrueba.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        public EmpleadoService _empleadoService;

        public EmpleadoController(EmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet]
        public ActionResult<List<Empleado>> Get()
        {
            return _empleadoService.Get();
        }

        [HttpGet("Autentication")]
        public ActionResult<Empleado> Autentication(Empleado  e)
        {
            return _empleadoService.Autentication(e.usuario, e.contrasena).First();
        }

        [HttpGet("{id}")]
        public ActionResult<Empleado> FindById(String id)
        {
            return _empleadoService.FindById(id).First();
        }

        [HttpGet("getbyNombreApellido/{n}")]
        public ActionResult<List<Empleado>> FindByNombreApellido(String n)
        {
            return _empleadoService.FindByNombreApellido(n);
        }



        [HttpPost]
        public ActionResult<List<Empleado>> Create(Empleado empleado)
        {
             _empleadoService.Create(empleado);
            return Ok(empleado);
        }

        [HttpPut]
        public ActionResult Update(Empleado empleado)
        {
            _empleadoService.Update(empleado.id, empleado);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(String id)
        {
            _empleadoService.Delete(id);
            return Ok();
        }
    }
}
