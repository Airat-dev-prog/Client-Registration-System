
namespace CRS.Centrum.Core.Entities
{
    public class Appointment
        : BaseEntity
    {
        public DateTime AppointmentDateTime
        { get; set; }

        public Guid MasterId
        { get; set; }
        public Master Master 
        { get; set; }

        public Guid ClientId
        { get; set; }
        public Client Client 
        { get; set; }

        public Guid ServiceId
        { get; set; }
        public Service Service 
        { get; set; }

        public Guid OfficeId
        { get; set; }
        public Office Office
        { get; set; }
    }
}
