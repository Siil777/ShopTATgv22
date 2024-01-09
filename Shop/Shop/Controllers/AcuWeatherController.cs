using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.AccuWeather;
using Shop.Core.Dto.CoctailDto;
using Shop.Core.ServiceInterface;
using Shop.Models.Acuweather;
using Shop.Models.Coctails;

namespace Shop.Controllers
{
    [Authorize]
    public class AcuWeatherController : Controller
    {


        private readonly IAcuWeatherServices _accuweatherServices;


        public AcuWeatherController(IAcuWeatherServices acuWeatherServices)
        {
            _accuweatherServices = acuWeatherServices;
        }

        [HttpPost]
        public IActionResult SearchCity(SeachAcuweatherViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "Acuweather", new { city = model.CityName });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
           
            AcuWeatherResultDto dto = new AcuWeatherResultDto();


            dto.City = city;

            _accuweatherServices.AcuWeatherResult(dto);



            AcuweatherIndexViewModel vm = new AcuweatherIndexViewModel
            {

                City = dto.City,

                
               
                Minimum = dto.Minimum,
                Maximum = dto.Maximum,
                Link = dto.Link,
                IconPhrase = dto.IconPhrase,
                Text = dto.Text


            };

         
            return View(vm);
        }

        public IActionResult Index()
        {
            return View();
        }
    }

}
