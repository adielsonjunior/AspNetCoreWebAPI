using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        public readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllAlunos(true));

        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {

            var aluno = _repo.GetAlunoById(id, true);

            if (aluno == null) return BadRequest();

            return Ok(aluno);

        }



        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {

            _repo.Add(aluno);
            var retorno = _repo.SaveChanges();

            if (!retorno)
            {
                return BadRequest("Aluno não foi salvo corretamente!");
            }

            return Ok(aluno);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id, false);
            if (alu == null) return BadRequest("Aluno não encontrato.");


            _repo.Update(aluno);
            _repo.SaveChanges();

            return Ok();

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _repo.GetAlunoById(id, false);
            if (alu == null) return BadRequest("Aluno não encontrato.");

            _repo.Update(aluno);
            _repo.SaveChanges();

            return Ok(aluno);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var alu = _repo.GetAlunoById(id, false);
            if (alu == null) return BadRequest("Aluno não encontrato.");

            _repo.Delete(alu);
            _repo.SaveChanges();

            return Ok();

        }



    }


}
