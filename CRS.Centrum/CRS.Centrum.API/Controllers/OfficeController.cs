using CRS.Centrum.Core.Entities;
using CRS.Centrum.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRS.Centrum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficesController : ControllerBase
    {
        private readonly OfficeSrv _officeService;

        public OfficesController(OfficeSrv officeService)
        {
            _officeService = officeService;
        }

        [HttpGet]
        public async Task<IEnumerable<Office>> GetOfficesAsync()
        {
            var _officesList = await _officeService.GetOfficesAsync();

            return _officesList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Office>> GetOfficeAsync(Guid id)
        {
            var _office = await _officeService.GetOfficeAsync(id);

            if (_office == null)
                return NotFound();

            return _office!;
        }

        [HttpPost]
        public async Task<ActionResult<Office>> CreateOfficeAsync(Office office)
        {
            var _office = await _officeService.CreateOfficeAsync(office);

            return _office;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Office>> EditOfficeAsync(Guid id, Office office)
        {
            var _office = await _officeService.EditOfficeAsync(id, office);

            if (_office == null)
                return NotFound();

            return _office;
           
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Office>> DeleteOfficeAsync(Guid id)
        {
            var _office = await _officeService.DeleteOfficeAsync(id);

            if (_office == null)
                return NotFound();

            return _office;
        }
    }
}
