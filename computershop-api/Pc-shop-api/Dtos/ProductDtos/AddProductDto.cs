﻿namespace computershopAPI.Dtos.ProductDtos
{
    public class AddProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string ShortDesc { get; set; } = string.Empty;
        public string LongDesc { get; set; } = string.Empty;
        public int Quantity { get; set; } = 1;
        public string Manufacturer { get; set; } = string.Empty;
        public double Price { get; set; } = 100;
        public double Rating { get; set; } = 3.0;
        public string Cover { get; set; } = string.Empty;
        public ImageArrayDto Images { get; set; }
        public int ComponentId { get; set; }

    }
}
