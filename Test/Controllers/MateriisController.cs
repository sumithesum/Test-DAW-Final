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
    public class MateriisController : ControllerBase
    {
        private readonly MateriiInterface _materiiInterface;
        public MateriisController(MateriiInterface matInterface)
        {

            _materiiInterface = matInterface;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Materii>))]

        public IActionResult GetMaterii()
        {

            var mat = _materiiInterface.GetMaterii();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(mat);
        }
        [HttpGet("{matId}")]
        [ProducesResponseType(200, Type = typeof(Materii))]
        [ProducesResponseType(400)]

        public IActionResult GetProf(int profId)
        {

            if (!_materiiInterface.MateriiExists(profId))
                return NotFound();

            var prof = _materiiInterface.GetMat(profId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(prof);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult CreateMat([FromBody] Materii materiiCreate)
        {

            if (materiiCreate == null)
            {
                ModelState.AddModelError("", "NU E BINE CV");
                return StatusCode(451, ModelState);
            }

            var mat = _materiiInterface.GetMaterii().Where(c => c.Name.ToLower() == materiiCreate.Name.TrimEnd().ToLower())
                .FirstOrDefault();

            if (mat != null)
            {
                ModelState.AddModelError("", "E deja o mat asa");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (!_materiiInterface.AdaugaMaterie(mat))
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

        public IActionResult UpdateMat(int matid, [FromBody] Materii mat)
        {

            if (mat == null ) return BadRequest(ModelState);

            if (matid != mat.Id)
                return BadRequest(ModelState);

            if (!_materiiInterface.MateriiExists(mat.Id))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            if (_materiiInterface.MaterieUpdate(mat))
            {
                ModelState.AddModelError("", "IDK CEVA LA UPDATE");
                return StatusCode(500, ModelState);
            }

            return Ok("Suces");
        }

    }
}
