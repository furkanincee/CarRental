using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var results =  _carService.GetAll();
            if (results.Success)
            {
               return Ok(results);
            }
            return BadRequest();
           
        } 
    }
}
