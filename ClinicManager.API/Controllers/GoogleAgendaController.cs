using ClinicManager.Application.GoogleCalendary;
using ClinicManager.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleAgendaController : ControllerBase
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateEventGoogleCalendar([FromBody] GoogleCalendario request)
        {
            return Ok(await EventosGoogleAgendaService.CreateGoogleCalendar(request));
        }

        [HttpPost("CreateQuick")]
        public async Task<IActionResult> CreateQuickEventGooleCalendar([FromBody] GoogleQuickCalendar request)
        {
            var eventCreated = await EventosGoogleAgendaService.CreateQuickEventGoogleCalendar(request.Description);

            return Ok(eventCreated);
        }
    }
}
