
using slnHolidaysColombia.Domain.HoliDayAggregate;

namespace slnHolidays.Domain.HoliDayAggregate
{
    public class HolidayColombia : IHolidayColombia
    {

        public DateTime Holiday { get; private set; }
        public string Celebration { get; private set; } = string.Empty;
        public bool IsWorkingDay { get; private set; }
        private int Year;
        private int EasterMonth;
        private int EasterDay;
        private List<WorkingDay> _holydayItems;
        public IReadOnlyCollection<WorkingDay> HolydayItems => _holydayItems;

        public HolidayColombia()
        {
            _holydayItems = new List<WorkingDay>();
        }


        public WorkingDay GetWorkingDayByDate(DateTime dateOfValidation)
        {
            GetAllHolidayByYear(dateOfValidation.Year);
            var holiday = _holydayItems.FirstOrDefault(x => x.CelebrationDay == dateOfValidation);

            if (holiday != null)
            {
                return new WorkingDay(holiday.CelebrationDay, holiday.Celebration, false);
            }
            else
            {
                if (dateOfValidation.DayOfWeek == DayOfWeek.Sunday || dateOfValidation.DayOfWeek == DayOfWeek.Saturday)
                {
                    return new WorkingDay(dateOfValidation, DescriptionCelebration.WEEKEND, false);
                }
                else
                {
                    return new WorkingDay(dateOfValidation, string.Empty, true);
                }
            }
        }

        public List<WorkingDay> GetAllHolidayByYear(int year)
        {
            this.Year = year;
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int g = (8 * b + 13) / 25;
            int h = (19 * a + b - d - g + 15) % 30;
            int j = c / 4;
            int k = c % 4;
            int m = (a + 11 * h) / 319;
            int r = (2 * e + 2 * j - k - h + m + 32) % 7;
            this.EasterMonth = (h - m + r + 90) / 25;
            this.EasterDay = (h - m + r + this.EasterMonth + 19) % 32;
            this.EasterMonth--;
            AddListHoliday(1, 1, DescriptionCelebration.NEWYEAR); // Primero de Enero
            AddListHoliday(5, 1, DescriptionCelebration.BUSINESSDAY); // Dia del trabajo 1 de mayo
            AddListHoliday(7, 20, DescriptionCelebration.INDEPENDENCEDAY); //Independencia 20 de Julio
            AddListHoliday(8, 7, DescriptionCelebration.BOYACABATTLE); //Batalla de boyaca 7 de agosto
            AddListHoliday(12, 8, DescriptionCelebration.IMMACULATECONCEPTIONDAY);//Maria inmaculada 8 de diciembre
            AddListHoliday(12, 25, DescriptionCelebration.CHRISTMASDAY); //Navidad 25 de diciembre
            CalculateEmiliani(1, 6, DescriptionCelebration.THREEKINGSDAY);// Reyes magos 6 de enero
            CalculateEmiliani(3, 19, DescriptionCelebration.STJOSEPHDAY); //San jose 19 de marzo
            CalculateEmiliani(6, 29, DescriptionCelebration.SAINTPETERANDSAINTPAUL); //San pedro y san pablo 29 de junio
            CalculateEmiliani(8, 15, DescriptionCelebration.THEASSUMPTIONVIRGIN);//Asuncion 15 de agosto
            CalculateEmiliani(10, 12, DescriptionCelebration.DAYRACE);//Descubrimiento de america 12 de octubre - Día de la raza
            CalculateEmiliani(11, 1, DescriptionCelebration.ALLSAINTS);//Todos los santos 1 de noviembre
            CalculateEmiliani(11, 11, DescriptionCelebration.INDEPENDENCECARTAGENA);         //Independencia de cartagena 11 de noviembre
            CalculateOtherHoliday(-3, false, DescriptionCelebration.HOLYTHRUSDAY);  //jueves santos
            CalculateOtherHoliday(-2, false, DescriptionCelebration.HOLYFRIDAY);  //viernes santo
            CalculateOtherHoliday(40, true, DescriptionCelebration.ASCENSIONLORD);   //Asención del señor de pascua
            CalculateOtherHoliday(60, true, DescriptionCelebration.CORPHUSCHRISTI);   //Corpus cristi
            CalculateOtherHoliday(68, true, DescriptionCelebration.SACREDHEARTJESUS);   //Sagrado corazon   
            return _holydayItems;
        }

        private void AddListHoliday(int month, int day, string description)
        {
            DateTime date = new DateTime(this.Year, month, day);
            var item = new WorkingDay(date, description);
            _holydayItems.Add(item);
        }

        private void CalculateEmiliani(int month, int day, string description)
        {
            DateTime dateEmiliani = new DateTime(this.Year, month, day);

            switch (dateEmiliani.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    dateEmiliani = dateEmiliani.AddDays(1);
                    break;
                case DayOfWeek.Tuesday:
                    dateEmiliani = dateEmiliani.AddDays(6);
                    break;
                case DayOfWeek.Wednesday:
                    dateEmiliani = dateEmiliani.AddDays(5);
                    break;
                case DayOfWeek.Thursday:
                    dateEmiliani = dateEmiliani.AddDays(4);
                    break;
                case DayOfWeek.Friday:
                    dateEmiliani = dateEmiliani.AddDays(3);
                    break;
                case DayOfWeek.Saturday:
                    dateEmiliani = dateEmiliani.AddDays(2);
                    break;
                default:
                    break;
            }
            AddListHoliday(dateEmiliani.Month, dateEmiliani.Day, description);
        }
        private void CalculateOtherHoliday(int days, bool emiliani, string description)
        {
            DateTime holiday = new DateTime(this.Year, this.EasterMonth + 1, this.EasterDay);
            holiday = holiday.AddDays(days);

            if (emiliani)
            {
                CalculateEmiliani(holiday.Month, holiday.Day, description);
            }
            else
            {
                AddListHoliday(holiday.Month, holiday.Day, description);
            }
        }
    }
}
