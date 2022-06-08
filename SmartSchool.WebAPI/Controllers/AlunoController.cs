using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno(){
                Id = 1,
                Nome = "Marcos",
                Sobrenome= "Magela",
                Telefone = "12345688"
            },
            new Aluno(){
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Suplicy",
                Telefone = "123456999"
            },

             new Aluno(){
                Id = 2,
                Nome = "Maria",
                Sobrenome = "Luigi",
                Telefone = "1234569999"
            },
        };


        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);

        }
        
        [HttpGet("{id:int}")]
        public IActionResult GetbyId(int id) {

            var aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest();

            return Ok(aluno);
        
        }


        [HttpGet("{nome}")]
        public IActionResult GetbyName(string nome)
        {

            var aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome));

            if (aluno == null) return BadRequest();

            return Ok(aluno);

        }

        [HttpPost("{nome}")]
        public IActionResult Post(Aluno aluno)
        {
                  
            return Ok(aluno);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {

            return Ok();

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {

            return Ok(aluno);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok();

        }

      

    }


}
