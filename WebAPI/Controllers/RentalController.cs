using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class RentalController : Controller
    {
        IRentalService _rentalService;
        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Post")]
        public IActionResult Rent(Rental rental)
        {
            var results = _rentalService.Add(rental);
            if (results.Success)
            {
                return Ok(results);
            }
            return BadRequest();
        }
    }
}
