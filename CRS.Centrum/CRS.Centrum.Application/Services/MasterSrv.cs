using CRS.Offer.Core.Repositories.Base;
using CRS.Offer.Core.Entities;
using System.Diagnostics.Metrics;

namespace CRS.Offer.Application.Services
{
    public class MasterSrv
    {
        private readonly IRepository<Master> _masterRepository;
        public MasterSrv(IRepository<Master> masterRepository)
        {
            _masterRepository = masterRepository;
        }

        public async Task<IEnumerable<Master>> GetMastersAsync()
        {
            var masters = await _masterRepository.GetAllAsync();

            var mastersList = masters.Select(master =>
                new Master()
                {
                    Id = master.Id,
                    Name = master.Name,
                    OfficeId = master.OfficeId
                }).ToList();

            return mastersList;
        }

        public async Task<Master> GetMasterAsync(Guid id)
        {
            var master = await _masterRepository.GetByIdAsync(id);

            return master;
        }

        public async Task<Master> CreateMasterAsync(Master master)
        {
            var _master = new Master()
            {
                Id = Guid.NewGuid(),
                Name = master.Name,
                OfficeId = master.OfficeId
            };

            await _masterRepository.AddAsync(_master);

            return _master;
        }

        public async Task<Master> EditMasterAsync(Guid id, Master master)
        {
            var _master = await GetMasterAsync(id);

            if (_master == null) return null;

            _master.Name = master.Name;
            _master.OfficeId = master.OfficeId;

            await _masterRepository.UpdateAsync(_master);

            return _master;
        }

        public async Task<Master> DeleteMasterAsync(Guid id)
        {
            var master = await GetMasterAsync(id);

            if (master == null) return null;

            await _masterRepository.DeleteAsync(master);

            return master;
        }

    }
}
