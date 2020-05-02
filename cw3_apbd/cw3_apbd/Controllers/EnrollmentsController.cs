using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw3_apbd.Models;
using cw3_apbd.Service;
using cw3_apbd.Tools;
using Microsoft.AspNetCore.Mvc;

namespace cw3_apbd.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        private IStudentsDBService _studentDbService;

        public EnrollmentsController(IStudentsDBService studentDbService)
        {
            _studentDbService = studentDbService;
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentEnrollmentRequest requestStudent)
        {
            var newStudent = requestStudent.MapToStudent();
            newStudent.Semester = 1;
            FunctionData result = _studentDbService.InsertStudent(newStudent);

            if (!result.status)
                return BadRequest(result.message);
            return Ok(newStudent);
        }

        [HttpPost]
        [Route("promotions")]
        public IActionResult PromoteStudents(PromotionRequest request) {

            FunctionData result = _studentDbService.PromoteStudents(request.Semester, request.Studies);
            if (!result.status) 
            {
                return BadRequest(result.message);
            }
            return Ok(result.resultObject);
        }
        
    }
}