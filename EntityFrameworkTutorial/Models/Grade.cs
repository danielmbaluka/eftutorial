namespace EntityFrameworkTutorial.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Student Prefect { get; set; }
    }
}
