﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;
using Api.Services.IService;
using Api.Dtos;
using Api.Global;

namespace Api.Controllers
{
    [Route("api/teacher-evaluations")]
    [ApiController]
    public class TeacherEvaluationController : ControllerBase
    {
        private readonly ITeacherEvaluationService _service;

        public TeacherEvaluationController(ITeacherEvaluationService service)
        {
            _service = service;
        }

        // GET: api/TeacherEvaluation
        [HttpGet("search")]
        public async Task<ResponseObject> GetTeacherEvaluations()
        {
            return new ResponseObject { status = "success" };
        }

        // GET: api/TeacherEvaluation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherEvaluation>> GetTeacherEvaluation(int id)
        {
            var teacherEvaluation = await _service.GetById(id);

            if (teacherEvaluation == null)
            {
                return NotFound();
            }

            return Ok(teacherEvaluation);
        }

        // PUT: api/TeacherEvaluation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacherEvaluation(int id, TeacherEvaluationDto teacherEvaluation)
        {
            if (id != teacherEvaluation.Id)
            {
                return BadRequest();
            }

            await _service.Update(teacherEvaluation);

            return NoContent();
        }

        // POST: api/TeacherEvaluation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeacherEvaluation>> PostTeacherEvaluation(TeacherEvaluationDto teacherEvaluation)
        {
            await _service.Insert(teacherEvaluation);
            return NoContent();
        }

        [HttpGet("get-by-project")]
        public async Task<ResponseObject> GetByProject(int projectId)
        {
            return new ResponseObject { status = "success" };
        }
    }
}
