using MediatR;
using slnHolidays.Domain.HoliDayAggregate;
using slnHolidaysColombia.Application.Dto;
using slnHolidaysColombia.Application.Queries;

namespace slnHolidaysColombia.Application.Handlers
{
    public class GetAllHolidayByYearHandler : IRequestHandler<GetAllHolidayByYearQuery, List<HolidayDto>>
    {
        private IHolidayColombia _holidayCalendarStrategy;

        public GetAllHolidayByYearHandler(IHolidayColombia holidayCalendarStrategy)
        {
            _holidayCalendarStrategy = holidayCalendarStrategy;
        }


        public async Task<List<HolidayDto>> Handle(GetAllHolidayByYearQuery request, CancellationToken cancellationToken)
        {
            var result = _holidayCalendarStrategy.GetAllHolidayByYear(request.Year);
            return HolidayDto.HolidayDtoFromHoliday(result);
        }
    }
}
