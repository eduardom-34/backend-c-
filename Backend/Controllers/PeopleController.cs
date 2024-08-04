using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")]
        public People Get(int id) => Repository.People.First(p => p.Id == id);

        [HttpGet("search/{search}")]

        public List<People> Get(string search) =>
            Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();
    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People()
            {
                Id = 1, Name = "Pedro", Birthdate = new DateTime(1990, 12, 3)
            },
            new People()
            {
                Id = 2, Name = "Luis", Birthdate = new DateTime(1992, 11, 3)
            },
            new People()
            {
                Id = 3, Name = "Ana", Birthdate = new DateTime(1985, 1, 8)
            },
            new People()
            {
                Id = 4, Name = "Hugo", Birthdate = new DateTime(1995, 1, 30)
            },
        };
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

}
