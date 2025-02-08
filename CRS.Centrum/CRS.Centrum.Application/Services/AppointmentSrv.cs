using CRS.Centrum.Core.Entities;
using CRS.Centrum.Core.Repositories.Base;

namespace CRS.Centrum.Application.Services
{
    public class AppointmentSrv(IRepository<Appointment> _appointmentRepository)
    {
        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
        {
            var appointments = await _appointmentRepository.GetAllAsync();

            var appointmentsList = appointments.Select(appointment =>
                new Appointment()
                {
                    Id = appointment.Id,
                    AppointmentDateTime = appointment.AppointmentDateTime,
                    MasterId = appointment.MasterId,
                    ClientId = appointment.ClientId,
                    ServiceId = appointment.ServiceId,
                    OfficeId = appointment.OfficeId
                }).ToList();

            return appointmentsList;
        }

        public async Task<Appointment> GetAppointmentAsync(Guid id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            return appointment;
        }

        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            var _appointment = new Appointment()
            {
                Id = Guid.NewGuid(),
                AppointmentDateTime = appointment.AppointmentDateTime,
                MasterId = appointment.MasterId,
                ClientId = appointment.ClientId,
                ServiceId = appointment.ServiceId,
                OfficeId = appointment.OfficeId
            };

            await _appointmentRepository.AddAsync(_appointment);

            return _appointment;
        }

        public async Task<Appointment> EditAppointmentAsync(Guid id, Appointment appointment)
        {
            var _appointment = await GetAppointmentAsync(id);

            if (_appointment == null) return null;

            _appointment.AppointmentDateTime = appointment.AppointmentDateTime;
            _appointment.MasterId = appointment.MasterId;
            _appointment.ClientId = appointment.ClientId;
            _appointment.ServiceId = appointment.ServiceId;
            _appointment.OfficeId = appointment.OfficeId;

            await _appointmentRepository.UpdateAsync(_appointment);

            return _appointment;
        }

        public async Task<Appointment> DeleteAppointmentAsync(Guid id)
        {
            var appointment = await GetAppointmentAsync(id);

            if (appointment == null) return null;

            await _appointmentRepository.DeleteAsync(appointment);

            return appointment;
        }
    }
}
