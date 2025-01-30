
namespace CRS.Offer.Core.Entities
{
    public class Schedule
        : BaseEntity
    {
        public DateTime WhatDate
        { get; set; }

        public DateTime StartTime
        { get; set; }

        public DateTime FinishTime 
        { get; set; }

        public Guid MasterId
        { get; set; }

        public Master Master { get; set; }

        public Guid OfficeId
        { get; set; }
        public Office Office
        { get; set; }

    }
}
