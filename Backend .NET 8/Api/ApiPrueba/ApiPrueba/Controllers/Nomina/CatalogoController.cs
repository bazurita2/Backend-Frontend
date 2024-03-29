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
    public class CatalogoController : ControllerBase
    {
        public CatalogoService _catalogoService;

        public CatalogoController(CatalogoService catalogoService)
        {
            _catalogoService = catalogoService;
        }

        [HttpGet]
        public ActionResult<List<Catalogo>> Get()
        {
            return _catalogoService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Catalogo> FindById(String id)
        {
            return _catalogoService.FindById(id).First();
        }


        [HttpGet("getbyDesc/{desc}")]
        public ActionResult<List<Catalogo>> FindByDesc(String desc)
        {
            return _catalogoService.FindByDesc(desc);
        }


        [HttpPost]
        public ActionResult<List<Catalogo>> Create(Catalogo catalogo)
        {
             _catalogoService.Create(catalogo);
            return Ok(catalogo);
        }

        [HttpPut]
        public ActionResult Update(Catalogo catalogo)
        {
            _catalogoService.Update(catalogo.id, catalogo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(String id)
        {
            _catalogoService.Delete(id);
            return Ok();
        }
    }
}
