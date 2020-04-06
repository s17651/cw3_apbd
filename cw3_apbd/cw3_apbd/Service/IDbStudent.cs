using cw3_apbd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw3_apbd.Service
{
    public interface IDbStudent
    {
        public ICollection<Student> GetStudents();

        public Enrollment GetStudentEnrollment(string indexNumber);
    }
}
