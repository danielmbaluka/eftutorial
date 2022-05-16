using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkTutorial.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Grade? Grade { get; set; }
    }
}
