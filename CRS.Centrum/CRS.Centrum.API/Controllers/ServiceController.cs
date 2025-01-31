using CRS.Offer.Application.Services;
using CRS.Offer.Core.Entities;
using CRS.Offer.Core.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace CRS.Offer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ServiceSrv _serviceService;

        public ServicesController(ServiceSrv serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            var _servicesList = await _serviceService.GetServicesAsync();

            return _servicesList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetServiceAsync(Guid id)
        {
            var _service = await _serviceService.GetServiceAsync(id);

            if (_service == null)
                return NotFound();

            return _service!;
        }

        [HttpPost]
        public async Task<ActionResult<Service>> CreateServiceAsync(Service service)
        {
            var _service = await _serviceService.CreateServiceAsync(service);

            return _service;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Service>> EditServiceAsync(Guid id, Service service)
        {
            var _service = await _serviceService.EditServiceAsync(id, service);

            if (_service == null)
                return NotFound();

            return _service;

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Service>> DeleteServiceAsync(Guid id)
        {
            var _service = await _serviceService.DeleteServiceAsync(id);

            if (_service == null)
                return NotFound();

            return _service;
        }
    }
}
