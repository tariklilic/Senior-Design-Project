using Microsoft.AspNetCore.Mvc;
using computershopAPI.Services.ProductService;
using computershopAPI.Dtos.ProductDtos;
using AutoMapper;
using computershopAPI.Services.ComponentService;
using computershopAPI.Dtos.ComponentDtos;

namespace computershopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentService _componentService;
        private readonly IMapper _mapper;


        public ComponentController(IComponentService componentService, IMapper mapper)
        {
            _componentService = componentService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddComponentDto newComponent)
        {
            return Ok(await _componentService.AddComponent(newComponent));

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _componentService.GetComponents());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _componentService.GetComponentById(id));
        }

    }
}
