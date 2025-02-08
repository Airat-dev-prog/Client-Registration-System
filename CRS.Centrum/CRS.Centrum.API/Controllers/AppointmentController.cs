using CRS.Centrum.Application.Services;
using CRS.Centrum.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CRS.Centrum.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentSrv _appointmentService;

        public AppointmentsController(AppointmentSrv appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
        {
            var _appointmentsList = await _appointmentService.GetAppointmentsAsync();

            return _appointmentsList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointmentAsync(Guid id)
        {
            var _appointment = await _appointmentService.GetAppointmentAsync(id);

            if (_appointment == null)
                return NotFound();

            return _appointment!;
        }

        [HttpPost]
        public async Task<ActionResult<Appointment>> CreateAppointmentAsync(Appointment client)
        {
            var _appointment = await _appointmentService.CreateAppointmentAsync(client);

            return _appointment;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Appointment>> EditAppointmentAsync(Guid id, Appointment client)
        {
            var _appointment = await _appointmentService.EditAppointmentAsync(id, client);

            if (_appointment == null)
                return NotFound();

            return _appointment;

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointment>> DeleteAppointmentAsync(Guid id)
        {
            var _appointment = await _appointmentService.DeleteAppointmentAsync(id);

            if (_appointment == null)
                return NotFound();

            return _appointment;
        }
    }
}
