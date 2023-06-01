using System.Data;
using AutoMapper;
using Azure;
using computershopAPI.Auth;
using computershopAPI.Dtos.CartDtos;
using computershopAPI.Dtos.ProductDtos;
using computershopAPI.Dtos.UserDtos;
using computershopAPI.Services.Auth;
using computershopAPI.Services.CartService;
using computershopAPI.Services.ComponentService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace computershopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {

        private readonly ICartService _cartService;
        private readonly IMapper _mapper;


        public CartController(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _cartService.GetUserProducts(id));
        }


        [HttpPost]
        public async Task<IActionResult> AddToCart(CartItemDto cartItem)
        {
            return Ok(await _cartService.AddUserProduct(cartItem));
        }

        [HttpPut("RemoveFromCart")]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            return Ok(await _cartService.RemoveUserProduct(cartItemId));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductQuantity(int cartItemId, int quantity)
        {
            return Ok(await _cartService.UpdateUserProductQuantity(cartItemId, quantity));
        }
    }
}
