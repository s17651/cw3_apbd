using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cw3_apbd.Models
{
    public class StudentEnrollmentRequest
    {
        /*
        {
        "IndexNumber": "s1234",
        "FirstName": "Andrzej",
        "LastName": "Malewski",
        "BirthDate": "30.03.1993"
        "Studies": "IT"
        }
        */
        [Required]
        [RegularExpression("^s[0-9]+$")]
        public String IndexNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [DataType("YYYY-MM-DD")]
        public string BirthDate { get; set; }
        [Required]
        [MaxLength(2)]
        public string StudiesName { get; set; }

        public Student MapToStudent()
        {
            Student resultStudent = new Student
            {
                IndexNumber = this.IndexNumber,
                FirstName = this.FirstName,
                LastName = this.LastName,
                BirthDate = this.BirthDate,
                StudiesName = this.StudiesName
            };

            return resultStudent;
        }

    }
}

