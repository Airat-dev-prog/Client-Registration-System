using CRS.Offer.Core.Entities;
using CRS.Offer.Core.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace CRS.Offer.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IRepository<Service> _serviceRepository;

        public ServiceController(IRepository<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Service>> GetServiceAsync()
        {
            var services = await _serviceRepository.GetAllAsync();

            var servicesList = services.Select(x =>
                new Service()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    Duration = x.Duration,
                    MasterId = x.MasterId,
                    OfficeId = x.OfficeId
                }).ToList();

            return servicesList;
        }

    }
}
