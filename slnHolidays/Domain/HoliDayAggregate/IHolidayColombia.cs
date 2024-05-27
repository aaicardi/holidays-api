namespace slnHolidays.Domain.HoliDayAggregate
{
    public interface IHolidayColombia
    {
        WorkingDay GetWorkingDayByDate(DateTime dateOfValidation);
        List<WorkingDay> GetAllHolidayByYear(int year);
    }
}
