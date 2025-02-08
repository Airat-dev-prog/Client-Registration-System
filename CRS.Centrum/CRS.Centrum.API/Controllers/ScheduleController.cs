using CRS.Centrum.Application.Services;
using CRS.Centrum.Core.Entities;
using CRS.Centrum.Core.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace CRS.Centrum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchedulesController : ControllerBase
    {
        private readonly ScheduleSrv _scheduleService;

        public SchedulesController(ScheduleSrv scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet]
        public async Task<IEnumerable<Schedule>> GetSchedulesAsync()
        {
            var _schedulesList = await _scheduleService.GetSchedulesAsync();

            return _schedulesList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetScheduleAsync(Guid id)
        {
            var _schedule = await _scheduleService.GetScheduleAsync(id);

            if (_schedule == null)
                return NotFound();

            return _schedule!;
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> CreateScheduleAsync(Schedule schedule)
        {
            var _schedule = await _scheduleService.CreateScheduleAsync(schedule);

            return _schedule;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Schedule>> EditScheduleAsync(Guid id, Schedule schedule)
        {
            var _schedule = await _scheduleService.EditScheduleAsync(id, schedule);

            if (_schedule == null)
                return NotFound();

            return _schedule;

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Schedule>> DeleteScheduleAsync(Guid id)
        {
            var _schedule = await _scheduleService.DeleteScheduleAsync(id);

            if (_schedule == null)
                return NotFound();

            return _schedule;
        }
    }
}
