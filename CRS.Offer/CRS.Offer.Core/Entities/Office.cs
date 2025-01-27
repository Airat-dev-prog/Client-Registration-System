
namespace CRS.Offer.Core.Entities
{
    public class Office
        : BaseEntity
    {
        public string Name
        { get; set; } = string.Empty;

        public string Address
        { get; set; } = string.Empty;

        public DateTime StartTime
        { get; set; }

        public DateTime FinishTime
        { get; set; }

        public List<Master> Masters 
        { get; set; }

        public List<Service> Services 
        { get; set; }

        public List<Schedule> Schedules 
        { get; set; }
    }
}
