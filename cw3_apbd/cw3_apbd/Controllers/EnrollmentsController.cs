using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using cw3_apbd.Models;
using cw3_apbd.Service;
using cw3_apbd.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace cw3_apbd.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        private IStudentsDBService _studentDbService;
        private IConfiguration Configuration;

        public EnrollmentsController(IStudentsDBService studentDbService, IConfiguration configuration)
        {
            _studentDbService = studentDbService;
            Configuration = configuration;
        }

        [HttpPost]
        [Authorize(Roles = "employee")]
        [Route("new_student")]
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
        [Authorize(Roles = "employee")]
        [Route("promotions")]
        public IActionResult PromoteStudents(PromotionRequest request) {

            FunctionData result = _studentDbService.PromoteStudents(request.Semester, request.Studies);
            if (!result.status) 
            {
                return BadRequest(result.message);
            }
            return Ok(result.resultObject);
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            Student student = _studentDbService.GetStudent(request.Login);
            
            if (student == null || !student.Password.Equals(SHA256Coder.GetHashFromString(request.password)))
            {
                return BadRequest("Wrong password or index number");
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, student.IndexNumber),
                new Claim(ClaimTypes.Name, student.FirstName + " " + student.LastName),
                new Claim(ClaimTypes.Role, "admin"),
                new Claim(ClaimTypes.Role, "student"),
                new Claim(ClaimTypes.Role, "employee")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer: "s17651",
                    audience: "Students",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: creds
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                refreshToken=Guid.NewGuid()
                //zapis refreshToken na baze + dodatkowy endpoint do logowania za pomocą refreshTokena
            });

        }

    }
}