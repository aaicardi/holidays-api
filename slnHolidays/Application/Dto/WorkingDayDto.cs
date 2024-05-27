using slnHolidays.Domain.HoliDayAggregate;

namespace slnHolidaysColombia.Application.Dto
{
    public class WorkingDayDto
    {
        public bool IsWorkingDay { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public static WorkingDayDto WorkingDayDtoFromWorkingDay(WorkingDay working)
        {
            return new WorkingDayDto
            {
                 Date = working.CelebrationDay,
                 Description = working.Celebration,
                 IsWorkingDay = working.IsWorkingDay,
            };
        }
    }
}
