using EntityFrameworkTutorial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTutorial.Controllers
{
    [Route("[controller]")]
    public class StudentsController: ControllerBase
    {
        private SchoolContext _schoolContext;
        public StudentsController(SchoolContext schoolContext)
        {
            this._schoolContext = schoolContext;
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _schoolContext.Students.Include(s => s.Grade);
        }

        [HttpPost]
        public Student Create([FromBody] Student student)
        {
            this._schoolContext.Students.Add(student);
            this._schoolContext.SaveChanges();
            return student;
        }
    }
}
