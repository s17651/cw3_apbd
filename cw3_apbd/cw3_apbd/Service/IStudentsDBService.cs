using cw3_apbd.Models;
using cw3_apbd.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw3_apbd.Service
{
    public interface IStudentsDBService
    {
        public FunctionData InsertStudent(Student student);
        public FunctionData PromoteStudents(int semesterm, string studies);
        public Student GetStudent(string indexNumber);
    }
}
