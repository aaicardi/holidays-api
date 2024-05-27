using MediatR;
using slnHolidaysColombia.Application.Dto;

namespace slnHolidaysColombia.Application.Queries
{
    public class GetWorkingDayByDateQuery : IRequest<WorkingDayDto>
    {
        public DateTime Date { get; set; }
    }
}
