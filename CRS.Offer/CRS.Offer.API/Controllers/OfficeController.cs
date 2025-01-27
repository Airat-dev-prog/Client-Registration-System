using CRS.Offer.Core.Entities;
using CRS.Offer.Core.Repositories.Base;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;

namespace CRS.Offer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfficeController : ControllerBase
    {
        private readonly IRepository<Office> _officeRepository;

        public OfficeController(IRepository<Office> officeRepository)
        {
            _officeRepository = officeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Office>> GetOfficeAsync()
        {
            var offices = await _officeRepository.GetAllAsync();

            var officesList = offices.Select(x =>
                new Office()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    StartTime = x.StartTime,
                    FinishTime = x.FinishTime
                }).ToList();

            return officesList;
        }
    }
}
