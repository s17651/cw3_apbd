using cw3_apbd.Models;
using cw3_apbd.Tools;
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

        public Enrollment GetStudentEnrollment(string indexNumber)
        {
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
                if (dr.Read())
                {
                    var enrollment = new Enrollment
                    {
                        IdEnrollment = (int)dr["IdEnrollment"],
                        Semester = (int)dr["Semester"],
                        IdStudy = (int)dr["IdStudy"],
                        StartDate = dr["StartDate"].ToString()
                    };

                    return enrollment;
                }
            }
            return null;
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
                    var student = new Student
                    {
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        BirthDate = dr["BirthDate"].ToString(),
                        StudiesName = dr["Name"].ToString(),
                        Semester = (int)dr["Semester"]
                    };
                    resultList.Add(student);
                }
            }
            return resultList;
        }
    }
}
