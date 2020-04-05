using cw3_apbd.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace cw3_apbd.Service
{
    public class DbStudent : IDbStudent
    {
        private const string ConString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s17651;Integrated Security=True";

        public ICollection<Enrollment> GetStudentEnrollments(string indexNumber)
        {
            var resultList = new List<Enrollment>();
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select et.IdEnrollment, et.Semester, et.IdStudy, et.StartDate " +
                                  "from student st, Enrollment et " +
                                  "where st.IdEnrollment = et.IdEnrollment " +
                                  "and st.Indexnumber=@index";

                com.Parameters.AddWithValue("index", indexNumber);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var enrollment = new Enrollment();
                    enrollment.IdEnrollment = (int)dr["IdEnrollment"];
                    enrollment.Semester = (int)dr["Semester"];
                    enrollment.IdStudy = (int)dr["IdStudy"];
                    enrollment.StartDate = dr["StartDate"].ToString();
                    resultList.Add(enrollment);

                }
            }
            return resultList;
        }

        public ICollection<Student> GetStudents()
        {
            var resultList = new List<Student>();
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select st.FirstName, st.LastName, st.BirthDate, ss.Name, et.Semester" +
                                  " from student st, Enrollment et, Studies ss " +
                                  "where st.IdEnrollment = et.IdEnrollment and st.IdEnrollment = ss.IdStudy ";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var student = new Student();
                    student.FirstName = dr["FirstName"].ToString();
                    student.LastName = dr["LastName"].ToString();
                    student.BirthDate = dr["BirthDate"].ToString();
                    student.StudiesName = dr["Name"].ToString();
                    student.Semester = (int)dr["Semester"];
                    resultList.Add(student);
                }
            }
            return resultList;
        }
    }
}
