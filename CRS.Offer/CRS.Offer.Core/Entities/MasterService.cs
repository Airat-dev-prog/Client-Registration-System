
namespace CRS.Offer.Core.Entities
{
    public class MasterService
    {
        public Guid MasterId
        { get; set; }

        public Master Master { get; set; }

        public Guid ServiceId
        { get; set; }

        public Service Service
        { get; set; }
    }
}
