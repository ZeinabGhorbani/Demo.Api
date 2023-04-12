using Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentdController : ControllerBase
    {
        private readonly DemoContext context;

        public StudentdController(DemoContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Std> Get()
        {
            return context.Stds.ToList();
        }

        [HttpGet("{id}")]
        public Std Get(int id)
        {
            return context.Stds.Find(id);
        }


        [HttpPut]
        public Std Update(Std std)
        {
            context.Stds.Update(std);
            context.SaveChanges();
            return std;
        }

        [HttpPost]
        public int Create(Std std)
        {
            context.Stds.Add(std);
            context.SaveChanges();
            return std.StdId;
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            context.Stds.Remove( new Std() { StdId =id });
            context.SaveChanges();
            return 1;
        }
    }
}
