using MediatR;
using slnHolidays.Domain.HoliDayAggregate;
using slnHolidaysColombia.Application.Dto;
using slnHolidaysColombia.Application.Queries;

namespace slnHolidaysColombia.Application.Handlers
{
    public class GetWorkingDayByDateHandler : IRequestHandler<GetWorkingDayByDateQuery, WorkingDayDto>
    {
        private IHolidayColombia _holidayCalendarStrategy;

        public GetWorkingDayByDateHandler(IHolidayColombia holidayCalendarStrategy)
        {
            _holidayCalendarStrategy = holidayCalendarStrategy;
        }

        public async Task<WorkingDayDto> Handle(GetWorkingDayByDateQuery request, CancellationToken cancellationToken)
        {

            var result = _holidayCalendarStrategy.GetWorkingDayByDate(request.Date);
            return WorkingDayDto.WorkingDayDtoFromWorkingDay(result);
        }
    }
}
