using CRS.Offer.Core.Entities;
using CRS.Offer.Core.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

namespace CRS.Offer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IRepository<Schedule> _scheduleRepository;

        public ScheduleController(IRepository<Schedule> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Schedule>> GetScheduleAsync()
        {
            var schedules = await _scheduleRepository.GetAllAsync();

            var schedulesList = schedules.Select(x =>
                new Schedule()
                {
                    Id = x.Id,
                    WhatDate = x.WhatDate,
                    StartTime = x.StartTime,
                    FinishTime = x.FinishTime,
                    MasterId = x.MasterId,
                    OfficeId = x.OfficeId
                }).ToList();

            return schedulesList;
        }
    }
}
