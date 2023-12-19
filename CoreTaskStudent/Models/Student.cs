using System.ComponentModel.DataAnnotations;

namespace CoreTaskStudent.Models
{
    public class Student
    {

        public int Student_id { get; set; }

        [Required(ErrorMessage = "Student name is required.")]
        public string Student_name { get; set; }

        [Required]
        public int Age { get; set; }
        [Required]
        public int Marks { get; set; }

        [Required]
        public string Result { get; set; }
    }
}
