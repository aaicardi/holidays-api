using MediatR;
using Microsoft.AspNetCore.Mvc;
using slnHolidaysColombia.Application.Queries;

namespace slnHolidaysColombia.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HolidayCalendarColombiaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HolidayCalendarColombiaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{date}/workingDay")]
        public async Task<IActionResult> GetWorkingDayByDateQuery(DateTime date)
        {
            var workingDay = await _mediator.Send(new GetWorkingDayByDateQuery
            {
                Date = date
            });
            return Ok(workingDay);
        }

        [HttpGet("{year}/holidays")]
        public async Task<IActionResult> GetAllHolidayByYearQuery(int year)
        {
            var holidays = await _mediator.Send(new GetAllHolidayByYearQuery
            {
                Year = year
            });
            return Ok(holidays);
        }

    }
}
