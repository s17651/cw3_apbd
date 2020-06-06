using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using cw3_apbd.Models;
using cw3_apbd.Models_cw10;
using cw3_apbd.Service;
using Microsoft.AspNetCore.Mvc;
using Student = cw3_apbd.Models_cw10.Student;

namespace cw3_apbd.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        
        //private IDbStudent _dbStudent;
        private s17651Context _s17651Context;

        //public StudentsController(IDbStudent dbStudent)
        //
        //    _dbStudent = dbStudent;
        //}
        public StudentsController(s17651Context s17651Context) 
        {
            _s17651Context = s17651Context;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            //var list = _dbStudent.GetStudents();
            var list = _s17651Context.Student.ToList();
            return Ok(list);
        }

        [HttpGet("{indexNumber}")]
        public IActionResult GetStudentEnrollments(string indexNumber)
        {
            //var enrollment = _dbStudent.GetStudentEnrollment(indexNumber);
            var enrollment = _s17651Context.Enrollment.Where(e => 
                            e.IdEnrollment.Equals(_s17651Context.Student.Where(s => 
                                  s.IndexNumber.Equals(indexNumber)).First())).First();
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }

        [HttpPost]
        public IActionResult CreateStudent(Models_cw10.Student student) 
        {
            student.IndexNumber = $"s{new Random().Next(1, 10000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id)
        {
            return Ok("Aktualizacja dokończona");
        }

        [HttpPut]
        public IActionResult PutStudent(Models_cw10.Student student)
        {
            _s17651Context.Attach(student);
            _s17651Context.SaveChanges();
            return Ok("Dodano studenta");
        }

        [HttpDelete("{indexNumber}")]
        public IActionResult DeleteStudent(String indexNumber)
        {
            Student student = new Student
            {
                IndexNumber = indexNumber
            };
            _s17651Context.Attach(student);
            _s17651Context.Remove(student);
            _s17651Context.SaveChanges();
            return Ok("Usuwanie ukończone");
        }
    }
}