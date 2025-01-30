using CRS.Offer.Core.Repositories.Base;
using CRS.Offer.Core.Entities;
using System.Diagnostics;
using System.Xml.Linq;

namespace CRS.Offer.Application.Services
{
    public class ServiceSrv
    {
        private readonly IRepository<Service> _serviceRepository;
        public ServiceSrv(IRepository<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            var services = await _serviceRepository.GetAllAsync();

            var servicesList = services.Select(service =>
                new Service()
                {
                    Id = service.Id,
                    Name = service.Name,
                    Price = service.Price,
                    Duration = service.Duration,
                    MasterId = service.MasterId,
                    OfficeId = service.OfficeId
                }).ToList();

            return servicesList;
        }

        public async Task<Service> GetServiceAsync(Guid id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);

            return service;
        }


        public async Task<Service> CreateServiceAsync(Service service)
        {
            var _service = new Service()
            {
                Id = Guid.NewGuid(),
                Name = service.Name,
                Price = service.Price,
                Duration = service.Duration,
                MasterId = service.MasterId,
                OfficeId = service.OfficeId
            };

            await _serviceRepository.AddAsync(_service);

            return _service;
        }

        public async Task<Service> EditServiceAsync(Guid id, Service service)
        {
            var _service = await GetServiceAsync(id);

            if (_service == null) return null;

            _service.Name = service.Name;
            _service.Price = service.Price;
            _service.Duration = service.Duration;
            _service.MasterId = service.MasterId;
            _service.OfficeId = service.OfficeId;

            await _serviceRepository.UpdateAsync(_service);

            return _service;
        }

        public async Task<Service> DeleteServiceAsync(Guid id)
        {
            var service = await GetServiceAsync(id);

            if (service == null) return null;

            await _serviceRepository.DeleteAsync(service);

            return service;
        }

    }
}
