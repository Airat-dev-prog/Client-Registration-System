using CRS.Centrum.Core.Entities;
using CRS.Centrum.Core.Repositories.Base;

namespace CRS.Centrum.Application.Services
{
    public class ClientSrv(IRepository<Client> _clientRepository)
    {
        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            var clients = await _clientRepository.GetAllAsync();

            var clientsList = clients.Select(client =>
                new Client()
                {
                    Id = client.Id,
                    Name = client.Name,
                    BornDate = client.BornDate,
                    OfficeId = client.OfficeId
                }).ToList();

            return clientsList;
        }

        public async Task<Client> GetClientAsync(Guid id)
        {
            var client = await _clientRepository.GetByIdAsync(id);

            return client;
        }


        public async Task<Client> CreateClientAsync(Client client)
        {
            var _client = new Client()
            {
                Id = Guid.NewGuid(),
                Name = client.Name,
                BornDate = client.BornDate,
                OfficeId = client.OfficeId
            };

            await _clientRepository.AddAsync(_client);

            return _client;
        }

        public async Task<Client> EditClientAsync(Guid id, Client client)
        {
            var _client = await GetClientAsync(id);

            if (_client == null) return null;

            _client.Name = client.Name;
            _client.BornDate = client.BornDate;
            _client.OfficeId = client.OfficeId;

            await _clientRepository.UpdateAsync(_client);

            return _client;
        }

        public async Task<Client> DeleteClientAsync(Guid id)
        {
            var client = await GetClientAsync(id);

            if (client == null) return null;

            await _clientRepository.DeleteAsync(client);

            return client;
        }
    }
}
