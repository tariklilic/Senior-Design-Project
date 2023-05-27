using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using computershopAPI.Dtos.ProductDtos;
using computershopAPI.Models.Models;

namespace computershopAPI.Helper
{
    public class PaginationResponse
    {
        public List<GetProductsDto> Products { get; set; } = new List<GetProductsDto>();
        public int Pages { get; set; } = 0;
        public int CurrentPage { get; set; }


    }
}
