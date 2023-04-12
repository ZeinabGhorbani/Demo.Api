using Api.Helper;
using Api.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StdController : Controller
    {
        private readonly DemoContext context;
        private readonly ExceptionTranslateService exceptionTranslateService;

        public StdController(DemoContext context, ExceptionTranslateService exceptionTranslateService)
        {
            this.context = context;
            this.exceptionTranslateService = exceptionTranslateService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            ApiResponseMassage<List<Std>> response = new ApiResponseMassage<List<Std>>();
            response.Data = context.Stds.ToList();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ApiResponseMassage<Std> response = new ApiResponseMassage<Std>();
            try
            {
                response.Data = context.Stds.Single(a => a.StdId == id);
            }
            catch (System.Exception ex)
            {
                response.AddError(exceptionTranslateService.Translate(ex.Message));
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpPut]
        public IActionResult Update(Std std)
        {
            context.Stds.Update(std);
            context.SaveChanges();
            return Accepted(std);
        }

        [HttpPost]
        public IActionResult Create(Std std)
        {
            ApiResponseMassage<int> response = new ApiResponseMassage<int>();
            try
            {
                context.Stds.Add(std);
                context.SaveChanges();
                response.Data = std.StdId;
            }
            catch (System.Exception ex)
            {
                response.AddError(ex.Message);
                return BadRequest(response);

            }

            return Created("",response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            context.Stds.Remove(new Std() { StdId = id });
            context.SaveChanges();
            return NoContent();
        }
    }
}
