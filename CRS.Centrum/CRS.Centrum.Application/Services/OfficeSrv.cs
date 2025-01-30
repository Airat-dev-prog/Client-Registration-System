using CRS.Offer.Core.Repositories.Base;
using CRS.Offer.Core.Entities;
using System.Net;
using System.Xml.Linq;

namespace CRS.Offer.Application.Services
{
    public class OfficeSrv
    {
        private readonly IRepository<Office> _officeRepository;
        public OfficeSrv(IRepository<Office> officeRepository)
        {
            _officeRepository = officeRepository;
        }

        public async Task<IEnumerable<Office>> GetOfficesAsync()
        {
            var offices = await _officeRepository.GetAllAsync();

            var officesList = offices.Select(office =>
                new Office()
                {
                    Id = office.Id,
                    Name = office.Name,
                    Address = office.Address,
                    StartTime = office.StartTime,
                    FinishTime = office.FinishTime
                }).ToList();

            return officesList;
        }

        public async Task<Office> GetOfficeAsync(Guid id)
        {
            var office = await _officeRepository.GetByIdAsync(id);

            return office;
        }

        public async Task<Office> CreateOfficeAsync(Office office)
        {
            var _office = new Office()
            {
                Id = Guid.NewGuid(),
                Name = office.Name,
                Address = office.Address,
                StartTime = office.StartTime,
                FinishTime = office.FinishTime
            };

            await _officeRepository.AddAsync(_office);

            return _office;
        }

        public async Task<Office> EditOfficeAsync(Guid id, Office office)
        {
            var _office = await GetOfficeAsync(id);

            if (_office == null) return null;

            _office.Name = office.Name;
            _office.Address = office.Address;
            _office.StartTime = office.StartTime;
            _office.FinishTime = office.FinishTime;

            await _officeRepository.UpdateAsync(_office);

            return _office;
        }

        public async Task<Office> DeleteOfficeAsync(Guid id)
        {
            var office = await GetOfficeAsync(id);

            if (office == null) return null;

            await _officeRepository.DeleteAsync(office);

            return office;
        }

    }
}
