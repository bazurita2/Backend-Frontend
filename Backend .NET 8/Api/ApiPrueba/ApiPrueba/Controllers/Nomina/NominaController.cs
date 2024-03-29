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
    public class NominaController : ControllerBase
    {
        public NominaService _nominaService;

        public NominaController(NominaService nominaService)
        {
            _nominaService = nominaService;
        }

        [HttpGet]
        public ActionResult<List<Nomina>> Get()
        {
            return _nominaService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Nomina> FindById(String id)
        {
            return _nominaService.FindById(id).First();
        }

        [HttpGet("FindByIdEmpleado/{id}")]
        public ActionResult<List<Nomina>> FindByIdEmpleado(String id)
        {
            return _nominaService.FindByIdEmpleado(id);
        }

        [HttpGet("FindByFechas/{dates}")]
        public ActionResult<List<Nomina>> FindByFechas(String dates)
        {
            RangoFechas rangoFechas = new RangoFechas();
            String[] splitDates= dates.Split(";");
            rangoFechas.lowerDate = Convert.ToDateTime(splitDates[0]);
            rangoFechas.higherDate = Convert.ToDateTime(splitDates[1]);
            return _nominaService.FindByFechas(rangoFechas.lowerDate, rangoFechas.higherDate);
        }
        

        [HttpPost]
        //public ActionResult<List<Nomina>> Create(Nomina nomina)
        public ActionResult<List<Nomina>> Create(NominaRubros nominaRubros)
        {
             _nominaService.Create(nominaRubros.nomina, nominaRubros.rubrosToInsert);
            return Ok(nominaRubros.rubrosToInsert);
        }

        [HttpPut]
        public ActionResult Update(Nomina nomina)
        {
            _nominaService.Update(nomina.id, nomina);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(String id)
        {
            _nominaService.Delete(id);
            return Ok();
        }
    }
}
