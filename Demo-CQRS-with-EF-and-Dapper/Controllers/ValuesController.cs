using CQRS.Queries.Animals;
using CQRS.Services;
using Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo_CQRS_with_EF_and_Dapper.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IAnimalService _animalService;

        public ValuesController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_animalService.Search(new GetAllAnimals()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AnimalDto dto)
        {
            var result = await _animalService.CreateAsync(dto);

            return Ok(result);
        }
    }
}
