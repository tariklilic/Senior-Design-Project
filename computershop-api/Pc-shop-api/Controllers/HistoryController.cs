using AutoMapper;
using computershopAPI.Services.CartService;
using computershopAPI.Services.HistoryService;
using Microsoft.AspNetCore.Mvc;


namespace computershopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase
    {

        private readonly ICartService _cartService;
        private readonly IHistoryService _historyService;
        private readonly IMapper _mapper;


        public HistoryController(ICartService cartService, IMapper mapper, IHistoryService historyService)
        {
            _cartService = cartService;
            _mapper = mapper;
            _historyService = historyService;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _historyService.GetHistory(id));
        }


        [HttpPost]
        public async Task<IActionResult> Purchase(string id)
        {
            return Ok(await _historyService.Purchase(id));
        }


    }
}
