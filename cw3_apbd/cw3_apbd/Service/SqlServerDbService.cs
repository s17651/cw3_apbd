using cw3_apbd.Models;
using cw3_apbd.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace cw3_apbd.Service
{
    public class SqlServerDbService : IStudentsDBService
    {
        private const string ConString = "Data Source=db-mssql16.pjwstk.edu.pl;Initial Catalog=s17651;Integrated Security=True";
        public FunctionData InsertStudent(Student student)
        {
            FunctionData result = new FunctionData(true);
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();
                var transaction = con.BeginTransaction();
                try
                {
                    //czy istnieje kierunek studiów?
                    com.CommandText = "select IdStudy from Studies where name=@name";
                    com.Parameters.AddWithValue("name", student.StudiesName);
                    com.Transaction = transaction;
                    var dr = com.ExecuteReader();
                    if (!dr.Read())
                    {
                        //jeżeli nie ma takiego to zwracamy błąd
                        dr.Close();
                        result.status = false;
                        result.message = "Incorrect Study name.";
                        return result;
                    }
                    int IdStudy = (int)dr["IdStudy"];
                    dr.Close();
                    com.Parameters.Clear();
                    //czy istnieje pierwszy semestr na tym kierunku?
                    com.CommandText = "select IdEnrollment from Enrollment where semester=@semester and IdStudy=@IdStudy order by StartDate desc";
                    com.Parameters.AddWithValue("semester", 1);
                    com.Parameters.AddWithValue("IdStudy", IdStudy);

                    dr = com.ExecuteReader();
                    int IdEnrollment;
                    if (!dr.Read())
                    {
                        dr.Close();
                        com.Parameters.Clear();
                        //jeżeli nie ma takiego to go dodajemy
                        com.CommandText = "select MAX(IdEnrollment) as IdEnrollment from Enrollment";
                        dr = com.ExecuteReader();
                        dr.Read();
                        int nextId = (int)dr["IdEnrollment"] + 1;
                        string StartDate = DateTime.Now.ToString();
                        dr.Close();
                        com.Parameters.Clear();

                        com.CommandText = "insert into Enrollment(IdEnrollment, Semester, IdStudy, StartDate) " +
                                          "values(@IdEnrollment, @Semester, @IdStudy, @StartDate)";
                        com.Parameters.AddWithValue("IdEnrollment", nextId);
                        com.Parameters.AddWithValue("Semester", 1);
                        com.Parameters.AddWithValue("IdStudy", IdStudy);
                        com.Parameters.AddWithValue("StartDate", StartDate);

                        com.ExecuteNonQuery();
                        com.Parameters.Clear();
                        IdEnrollment = nextId;
                    }
                    else
                    {
                        IdEnrollment = (int)dr["IdEnrollment"];
                        dr.Close();

                    }

                    //czy podany index jest unikalny?
                    com.CommandText = "select * from Student where indexnumber=@IndexNumber";
                    com.Parameters.AddWithValue("IndexNumber", student.IndexNumber);
                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        result.status = false;
                        result.message = "Index number is already taken.";
                        return result;
                    }
                    dr.Close();
                    com.Parameters.Clear();

                    com.CommandText = "insert into Student(IndexNumber, FirstName, LastName, BirthDate, IdEnrollment) " +
                                       "values(@IndexNumber, @FirstName, @LastName, @BirthDate, @IdEnrollment)";
                    com.Parameters.AddWithValue("IndexNumber", student.IndexNumber);
                    com.Parameters.AddWithValue("FirstName", student.FirstName);
                    com.Parameters.AddWithValue("LastName", student.LastName);
                    com.Parameters.AddWithValue("BirthDate", student.BirthDate);
                    com.Parameters.AddWithValue("IdEnrollment", IdEnrollment);

                    com.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (SqlException e)
                {
                    transaction.Rollback();
                    result.status = false;
                    result.message = "SQL exception!";
                    return result;
                }
            }

            return result;
        }

        public FunctionData PromoteStudents(int semester, string studies)
        {
            FunctionData result = new FunctionData(true);
            using (SqlConnection con = new SqlConnection(ConString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();
                //czy jest wpis w Enrollment o podanych wartościach semester i studies?
                com.CommandText = "Select * from Enrollment  where semester=@semester and IdStudy=(select idStudy from Studies where name=@studies)";
                com.Parameters.AddWithValue("studies", studies);
                com.Parameters.AddWithValue("semester", semester);
                var dr = com.ExecuteReader();
                if (!dr.Read())
                {
                    result.status = false;
                    result.message = "There is no Enrollment where semester = " + semester + " and studies = " + studies + "!";
                    return result;
                }
                dr.Close();
                //wywołanie procedury
                com.CommandText = "EXEC PromoteStudents @studies, @semester";

                int rows = com.ExecuteNonQuery();
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
                else if (rows > 0)
                {
                    com.CommandText = "Select * from Enrollment  where semester=@semester + 1 and IdStudy=(select idStudy from Studies where name=@studies) order by StartDate desc";
                    dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        var enrollment = new Enrollment
                        {
                            IdEnrollment = (int)dr["IdEnrollment"],
                            Semester = (int)dr["Semester"],
                            IdStudy = (int)dr["IdStudy"],
                            StartDate = dr["StartDate"].ToString()
                        };
                        result.resultObject = enrollment;
                    }
                }

            }
            return result;
        }
    }
}
