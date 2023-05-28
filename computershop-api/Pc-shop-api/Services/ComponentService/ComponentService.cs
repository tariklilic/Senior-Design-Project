using AutoMapper;
using computershopAPI.Data;
using computershopAPI.Dtos.ComponentDtos;
using computershopAPI.Models.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace computershopAPI.Services.ComponentService

{
    public class ComponentService : IComponentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ComponentService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }



        public async Task<ServiceResponse<GetComponentDto>> GetComponentById(int id)
        {
            var serviceResponse = new ServiceResponse<GetComponentDto>();

            var dbComponents = await _context.Components
                .Include(a => a.Products)
                .FirstOrDefaultAsync(a => a.Id == id);

            serviceResponse.Data = _mapper.Map<GetComponentDto>(dbComponents);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetComponentDto>>> GetComponents()
        {
            var serviceResponse = new ServiceResponse<List<GetComponentDto>>();

            var dbComponents = await _context.Components
                .Include(a => a.Products)
                .ToListAsync();
            serviceResponse.Data = dbComponents.Select(a => _mapper.Map<GetComponentDto>(a))
                .ToList();

            return serviceResponse;
        }




    }
}
