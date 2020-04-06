using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using cw3_apbd.Models;
using cw3_apbd.Service;
using Microsoft.AspNetCore.Mvc;

namespace cw3_apbd.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        

        private IDbStudent _dbStudent;

        public StudentsController(IDbStudent dbStudent)
        {
            _dbStudent = dbStudent;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var list = _dbStudent.GetStudents();

            return Ok(list);
        }

        [HttpGet("{indexNumber}")]
        public IActionResult GetStudentEnrollments(string indexNumber)
        {
            var enrollment = _dbStudent.GetStudentEnrollment(indexNumber);

            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student) 
        {
            student.IndexNumber = $"s{new Random().Next(1, 10000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {
            return Ok("Aktualizacja dokończona");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok("Usuwanie ukończone");
        }
    }
}