﻿using computershopAPI.Models.Models;

namespace computershopAPI.Dtos.ComponentDtos
{
    public class AddComponentDto
    {
        public string Name { get; set; } = String.Empty;
        public string Image { get; set; } = String.Empty;
        public ICollection<Product> Products { get; } = new List<Product>();
    }
}
