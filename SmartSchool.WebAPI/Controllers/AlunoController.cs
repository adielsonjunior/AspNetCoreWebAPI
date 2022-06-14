﻿using Microsoft.AspNetCore.Http;
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

        private readonly SmartContext _context;

        public AlunoController(SmartContext context)
        {
            _context = context;
        }
   
        [HttpGet]
        public IActionResult Get()
        {
             return Ok(_context.Alunos);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetbyId(int id)
        {

            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest();

            return Ok(aluno);

        }


        [HttpGet("{nome}")]
        public IActionResult GetbyName(string nome)
        {

            var aluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Nome.Contains(nome));

            if (aluno == null) return BadRequest();

            return Ok(aluno);

        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
           if (alu == null) return BadRequest("Aluno não encontrato.");

            _context.Update(aluno);
            _context.SaveChanges();

            return Ok();

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno não encontrato.");

            _context.Update(alu);
            _context.SaveChanges();
            return Ok(aluno);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno não encontrato.");

            _context.Remove(alu);
            return Ok();

        }



    }


}
