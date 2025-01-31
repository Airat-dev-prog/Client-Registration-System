using CRS.Offer.Application.Services;
using CRS.Offer.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRS.Offer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MastersController : ControllerBase
    {
        private readonly MasterSrv _masterService;

        public MastersController(MasterSrv masterService)
        {
            _masterService = masterService;
        }

        [HttpGet]
        public async Task<IEnumerable<Master>> GetMastersAsync()
        {
            var _masterList = await _masterService.GetMastersAsync();
            
            return _masterList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Master>> GetMasterAsync(Guid id)
        {
            var _master = await _masterService.GetMasterAsync(id);

            if (_master == null)
                return NotFound();

            return _master!;
        }


        [HttpPost]
        public async Task<ActionResult<Master>> CreateMasterAsync(Master master)
        {
            var _master = await _masterService.CreateMasterAsync(master);

            return _master;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Master>> EditMasterAsync(Guid id, Master master)
        {
            var _master = await _masterService.EditMasterAsync(id, master);

            if (_master == null)
                return NotFound();

            return _master;

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Master>> DeleteMasterAsync(Guid id)
        {
            var _master = await _masterService.DeleteMasterAsync(id);

            if (_master == null)
                return NotFound();

            return _master;
        }
    }
}
