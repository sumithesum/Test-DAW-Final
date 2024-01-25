using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Data;

using Test.Interface;
using Test.Model;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorisController : ControllerBase
    {
        private readonly ProfesoriInterface _profesoriInterface;
        public ProfesorisController(ProfesoriInterface profInterface)
        {
           
            _profesoriInterface = profInterface;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Profesori>))]

        public IActionResult GetProfesori()
        {

            var mat = _profesoriInterface.GetProfesori();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(mat);
        }

        [HttpGet("{ProfId}")]
        [ProducesResponseType(200, Type = typeof(Profesori))]
        [ProducesResponseType(400)]

        public IActionResult GetProf(int profId)
        {

            if (!_profesoriInterface.ProfesorExists(profId))
                return NotFound();

            var prof = _profesoriInterface.GetProf(profId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(prof);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult CreateProf([FromBody] Profesori profesoriCreate)
        {

            if (profesoriCreate == null || !(profesoriCreate.Tip.TrimEnd().ToLower() == "laboranti" || profesoriCreate.Tip.TrimEnd().ToLower() == "standart"))
            {
                ModelState.AddModelError("", "NU E BINE CV");
                return StatusCode(451, ModelState);
            }

            var prof = _profesoriInterface.GetProfesori().Where(c => c.Tip.ToLower() == profesoriCreate.Tip.TrimEnd().ToLower())
                .FirstOrDefault();

            if (prof != null)
            {
                ModelState.AddModelError("", "E deja un prof asa");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            

            if (!_profesoriInterface.AdaugaProf(profesoriCreate))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            return Ok("Succes");
        }

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateProf(int profid, [FromBody] Profesori prof)
        {

            if (prof == null || !(prof.Tip.TrimEnd().ToLower() == "laboranti" || prof.Tip.TrimEnd().ToLower() == "standart")) return BadRequest(ModelState);

            if (profid != prof.Id)
                return BadRequest(ModelState);

            if (!_profesoriInterface.ProfesorExists(prof.Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            

            if (_profesoriInterface.ProfUpdate(prof))
            {
                ModelState.AddModelError("", "IDK CEVA LA UPDATE");
                return StatusCode(500, ModelState);
            }

            return Ok("Suces");
        }
    }
}
