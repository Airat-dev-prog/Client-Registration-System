using CRS.Offer.Core.Repositories.Base;
using CRS.Offer.Core.Entities;

namespace CRS.Offer.Application.Services
{
    public class ScheduleSrv
    {
        private readonly IRepository<Schedule> _scheduleRepository;
        public ScheduleSrv(IRepository<Schedule> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<IEnumerable<Schedule>> GetSchedulesAsync()
        {
            var schedules = await _scheduleRepository.GetAllAsync();

            var schedulesList = schedules.Select(schedule =>
                new Schedule()
                {
                    Id = schedule.Id,
                    WhatDate = schedule.WhatDate,
                    StartTime = schedule.StartTime,
                    FinishTime = schedule.FinishTime,
                    MasterId = schedule.MasterId,
                    OfficeId = schedule.OfficeId
                }).ToList();

            return schedulesList;
        }

        public async Task<Schedule> GetScheduleAsync(Guid id)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(id);

            return schedule;
        }

        public async Task<Schedule> CreateScheduleAsync(Schedule schedule)
        {
            var _schedule = new Schedule()
            {
                Id = Guid.NewGuid(),
                WhatDate = schedule.WhatDate,
                StartTime = schedule.StartTime,
                FinishTime = schedule.FinishTime,
                MasterId = schedule.MasterId,
                OfficeId = schedule.OfficeId
            };

            await _scheduleRepository.AddAsync(_schedule);

            return _schedule;
        }

        public async Task<Schedule> EditScheduleAsync(Guid id, Schedule schedule)
        {
            var _schedule = await GetScheduleAsync(id);

            if (_schedule == null) return null;

            _schedule.WhatDate = schedule.WhatDate;
            _schedule.StartTime = schedule.StartTime;
            _schedule.FinishTime = schedule.FinishTime;
            _schedule.MasterId = schedule.MasterId;
            _schedule.OfficeId = schedule.OfficeId;

            await _scheduleRepository.UpdateAsync(_schedule);

            return _schedule;
        }

        public async Task<Schedule> DeleteScheduleAsync(Guid id)
        {
            var schedule = await GetScheduleAsync(id);

            if (schedule == null) return null;

            await _scheduleRepository.DeleteAsync(schedule);

            return schedule;
        }

    }
}
