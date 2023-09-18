using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Core.Domain;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Shop.Data;
using Shop.Models.Spaceship;

namespace Shop.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShopContext _context;
        private readonly ISpaceshipServices _spaceshipServices;

        public SpaceshipsController
            (
            ShopContext context,
            ISpaceshipServices spaceshipServices
            ) 
        {
            _context = context;
            _spaceshipServices = spaceshipServices;
        }

        public IActionResult Index()
        {
            var result = _context.Spaceships
                .Select(x => new SpaeshipsIndexViewModel
                {
                    Id= x.Id,
                    Name= x.Name, 
                    Type= x.Type, 
                    EnginPower= x.EnginPower,
                    Passangers= x.Passangers,
                });

            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            SpaceshipCreateUpdateViewModel spaceship =new SpaceshipCreateUpdateViewModel();

            return View("CreateUpdate", spaceship);
        }         


        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipCreateUpdateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                Passangers = vm.Passangers,
                EnginPower = vm.EnginPower,
                Crew = vm.Crew,
                Company = vm.Company,
                CargoWeight = vm.CargoWeight

            };

            var result = await _spaceshipServices.Create(dto);
            //return index
            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var spaceship = await _spaceshipServices.GetAsync(id);

            if (spaceship==null)
            {
                return NotFound();

            }

            var vm = new SpaceshipDetailsViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Type = spaceship.Type;
            
            vm.Passangers= spaceship.Passangers;
            
            vm.EnginPower= spaceship.EnginPower;
            vm.Crew = spaceship.Crew;
            vm.Company= spaceship.Company;
            vm.CargoWeight = spaceship.CargoWeight;
            vm.CreatedAt= spaceship.CreatedAt;
            vm.Modifieted= spaceship.Modifieted;


            return View(vm);



        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var spaceship = await _spaceshipServices.GetAsync(id); 

            if(spaceship==null)
            {
                return NotFound();
            }


            var vm = new SpaceshipCreateUpdateViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Type = spaceship.Type;

            vm.Passangers = spaceship.Passangers;

            vm.EnginPower = spaceship.EnginPower;
            vm.Crew = spaceship.Crew;
            vm.Company = spaceship.Company;
            vm.CargoWeight = spaceship.CargoWeight;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.Modifieted = spaceship.Modifieted;

            return View("CreateUpdate",vm);
        }
        [HttpPost]    
        public async  Task<IActionResult> Update(SpaceshipCreateUpdateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                Passangers = vm.Passangers,
                EnginPower = vm.EnginPower,
                Crew = vm.Crew,
                Company = vm.Company,
                CargoWeight = vm.CargoWeight,
                CreatedAt = vm.CreatedAt,
                Modifieted = DateTime.Now,
            };
            var result=await _spaceshipServices.Update(dto);
            if (result==null)
            {
                return RedirectToAction(nameof(Index),vm);

            }
            return RedirectToAction(nameof(Index), vm);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var spaceship=await _spaceshipServices.GetAsync(id);
            if (spaceship == null)
            {
                return NotFound();
            }
            var vm = new SpaceshipDeleteViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Type = spaceship.Type;

            vm.Passangers = spaceship.Passangers;

            vm.EnginPower = spaceship.EnginPower;
            vm.Crew = spaceship.Crew;
            vm.Company = spaceship.Company;
            vm.CargoWeight = spaceship.CargoWeight;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.Modifieted = spaceship.Modifieted;

            return View( vm);
        }
         


            



    }

}
