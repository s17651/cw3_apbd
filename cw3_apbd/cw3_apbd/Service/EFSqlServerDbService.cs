using cw3_apbd.Models;
using cw3_apbd.Models_cw10;
using cw3_apbd.Tools;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw3_apbd.Service
{
    public class EFSqlServerDbService : IStudentsDBService
    {
        private s17651Context _s17651Context;

        public EFSqlServerDbService(s17651Context s17651Context) {
            _s17651Context = s17651Context;
        }

        public Models.Student GetStudent(string indexNumber)
        {
            var student = _s17651Context.Student.Where(s => s.IndexNumber.Equals(indexNumber)).First();
            return (new Models.Student { 
                 BirthDate = student.BirthDate.ToString(),
                 FirstName = student.FirstName,
                 IndexNumber = student.IndexNumber,
                 LastName = student.LastName,
                 Password = student.Password,
            });
        }

        public FunctionData InsertStudent(Models.Student student)
        {
            FunctionData result = new FunctionData(true);
            //czy istnieje kierunek studiów?
            var study = _s17651Context.Studies.Where(s => s.Name.Equals(student.StudiesName)).First();
            if (study == null) 
            {
                result.status = false;
                result.message = "Incorrect Study name.";
                return result;
            }
            //czy istnieje pierwszy semestr na tym kierunku?
            var enrollment = _s17651Context.Enrollment.Where(e => e.IdStudy == study.IdStudy && e.Semester == 1).First();
            if (enrollment == null) 
            {
                var newEnrollment = new Models_cw10.Enrollment
                {
                    Semester = 1,
                    IdStudy = study.IdStudy,
                    StartDate = DateTime.Now
                };
                _s17651Context.Attach(newEnrollment);
                _s17651Context.SaveChanges();
            }
            //czy podany index jest unikalny?
            var uniqueStudent = _s17651Context.Student.Where(s => s.IndexNumber.Equals(student.IndexNumber)).First();
            if (uniqueStudent != null)
            {
                result.status = false;
                result.message = "Index number is already taken.";
                return result;
            }

            var newStudent = new Models_cw10.Student
            {
                BirthDate = DateTime.Parse(student.BirthDate),
                FirstName = student.FirstName,
                IdEnrollment = enrollment.IdEnrollment,
                IndexNumber = student.IndexNumber,
                LastName = student.LastName,
                Password = student.Password
            };

            _s17651Context.Attach(newStudent);
            return result;
        }

        public FunctionData PromoteStudents(int semester, string studies)
        {
            FunctionData result = new FunctionData(true);
            //czy jest wpis w Enrollment o podanych wartościach semester i studies?
            var enrollment = _s17651Context.Enrollment.Where(e => e.Semester == semester && studies == 
                            _s17651Context.Studies.Where(s => s.IdStudy == e.IdStudy).First().Name).First();
            if (enrollment == null)
            {
                result.status = false;
                result.message = "There is no Enrollment where semester = " + semester + " and studies = " + studies + "!";
                return result;
            }
            //wywołanie procedury
            var rows = _s17651Context.Database.ExecuteSqlRaw("EXEC PromoteStudents @" + studies +", @"+semester);
            //wystąpienie wyjątku
            if (rows < 0)
            {
                result.status = false;
                result.message = "Exception in Stored Procedure: PromoteStudents!";
            }
            //brak studentów
            else if (rows == 0)
            {
                result.status = false;
                result.message = "There were no Students to promote!";
            }
            var newEnrollment = _s17651Context.Enrollment.Where(e => e.Semester == semester+1 && studies ==
                                _s17651Context.Studies.Where(s => s.IdStudy == e.IdStudy).First().Name).GroupBy(e=> e.StartDate).First();

            result.resultObject = enrollment;
            return result;
        }
    }
}
