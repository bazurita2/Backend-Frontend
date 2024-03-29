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
    public class RubroController : ControllerBase
    {
        public RubroService _rubroService;

        public RubroController(RubroService rubroService)
        {
            _rubroService = rubroService;
        }

        [HttpGet]
        public ActionResult<List<Rubro>> Get()
        {
            return _rubroService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Rubro> FindById(String id)
        {
            return _rubroService.FindById(id).First();
        }

        [HttpGet("FindByIdNomina/{id}")]
        public ActionResult<List<Rubro>> FindByIdNomina(String id)
        {
            return _rubroService.FindByIdNomina(id);
        }

        [HttpPost]
        public ActionResult<List<Rubro>> Create(Rubro rubro)
        {
             _rubroService.Create(rubro);
            return Ok(rubro);
        }

        [HttpPut]
        public ActionResult Update(Rubro rubro)
        {
            _rubroService.Update(rubro.id, rubro);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(String id)
        {
            _rubroService.Delete(id);
            return Ok();
        }
    }
}
