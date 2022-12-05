using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        // fieldlerin defaultu privatemış
        ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var results = _carService.GetAll();
            if (results.Success)
            {
                return Ok(results);
            }
            return BadRequest();

        }
        [HttpPost("Add")]
        public IActionResult Add(Car car)
        {
            var results = _carService.Add(car);
            if (results.Success)
            {
                return Ok(results);
            }
            return BadRequest();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var results = _carService.GetById(id);
            if (results.Success)
            {
                return Ok(results);
            }
            return BadRequest();
        }
    }
}
