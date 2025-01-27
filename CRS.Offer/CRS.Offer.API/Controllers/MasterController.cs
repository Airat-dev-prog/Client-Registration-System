using CRS.Offer.Core.Entities;
using CRS.Offer.Core.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace CRS.Offer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MasterController : ControllerBase
    {
        private readonly IRepository<Master> _masterRepository;

        public MasterController(IRepository<Master> masterRepository)
        {
            _masterRepository = masterRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Master>> GetOfficeAsync()
        {
            var masters = await _masterRepository.GetAllAsync();

            var mastersList = masters.Select(x =>
                new Master()
                {
                    Id = x.Id,
                    Name = x.Name,
                    OfficeId = x.OfficeId
                }).ToList();

            return mastersList;
        }
    }
}
