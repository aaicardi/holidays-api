namespace slnHolidays.Domain.HoliDayAggregate
{
    public class WorkingDay
    {
        public DateTime CelebrationDay { get; private set; }
        public string Celebration { get; private set; }
        public bool IsWorkingDay { get; private set; }

        public WorkingDay(DateTime celebrationDay, string celebration, bool isWorkingDay)
        {
            CelebrationDay = celebrationDay;
            Celebration = celebration;
            IsWorkingDay = isWorkingDay;
        }

        public WorkingDay(DateTime celebrationDay, string celebration)
        {
            CelebrationDay = celebrationDay;
            Celebration = celebration;
        }
    }
}
