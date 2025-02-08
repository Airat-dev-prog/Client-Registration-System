
namespace CRS.Centrum.Core.Entities
{
    public class Service
        : BaseEntity
    {
        public string Name
        { get; set; } = string.Empty;

        public double Price 
        {  get; set; }

        public DateTime Duration
        { get; set; }

        public Guid MasterId
        { get; set; }

        public Guid OfficeId
        { get; set; }
        public Office Office
        { get; set; }

        public List<Appointment> Appointments
        { get; set; } = [];

        public List<MasterService> MasterService
        { get; set; } = [];
    }
}
