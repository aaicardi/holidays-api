using MediatR;
using slnHolidaysColombia.Application.Dto;

namespace slnHolidaysColombia.Application.Queries
{
    public class GetAllHolidayByYearQuery : IRequest<List<HolidayDto>>
    {
        public int Year { get; set; }
    }
}
