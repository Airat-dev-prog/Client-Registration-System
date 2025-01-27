
namespace CRS.Offer.Core.Entities
{
    public class Master
        : BaseEntity
    {
        public string Name 
        { get; set; } = string.Empty;
        
        public Guid OfficeId 
        { get; set; }

        public Office Office
        { get; set; }

        public List<MasterService> MasterService
        { get; set; }

        public List<Schedule> Schedules 
        { get; set; }

    }
}
