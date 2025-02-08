using CRS.Centrum.Application.Services;
using CRS.Centrum.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRS.Centrum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ClientSrv _clientService;

        public ClientsController(ClientSrv clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            var _clientsList = await _clientService.GetClientsAsync();

            return _clientsList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClientAsync(Guid id)
        {
            var _client = await _clientService.GetClientAsync(id);

            if (_client == null)
                return NotFound();

            return _client!;
        }

        [HttpPost]
        public async Task<ActionResult<Client>> CreateClientAsync(Client client)
        {
            var _client = await _clientService.CreateClientAsync(client);

            return _client;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Client>> EditClientAsync(Guid id, Client client)
        {
            var _client = await _clientService.EditClientAsync(id, client);

            if (_client == null)
                return NotFound();

            return _client;

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteClientAsync(Guid id)
        {
            var _client = await _clientService.DeleteClientAsync(id);

            if (_client == null)
                return NotFound();

            return _client;
        }
    }
}
