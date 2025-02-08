
namespace CRS.Centrum.Core.Entities
{
    public class Client
        : BaseEntity
    {
        public string Name
        { get; set; } = string.Empty;

        public DateTime BornDate
        { get; set; }

        public Guid OfficeId
        { get; set; }
        public Office Office
        { get; set; }

        public List<Appointment> Appointments
        { get; set; } = [];
    }
}
