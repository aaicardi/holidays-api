using slnHolidays.Domain.HoliDayAggregate;

namespace slnHolidaysColombia.Application.Dto
{
    public class HolidayDto
    {
        public DateTime Holiday { get; set; }
        public string Celebration { get; set; } = string.Empty;

        public static List<HolidayDto> HolidayDtoFromHoliday(List<WorkingDay> workingDays)
        {
            return workingDays.Select(x => new HolidayDto()
            {
                Celebration = x.Celebration,
                Holiday = x.CelebrationDay

            }).ToList();
        }
    }
}
