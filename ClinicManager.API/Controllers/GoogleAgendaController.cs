using ClinicManager.Application.GoogleCalendary;
using ClinicManager.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetEventsGooleCalendar()
        {
            return Ok(await EventosGoogleAgendaService.GetEventsGoogleCalendar());
        }

        [HttpGet("Get/{eventId}")]
        public async Task<IActionResult> GetEventGooleCalendar(string eventId)
        {
            return Ok(await EventosGoogleAgendaService.GetEventGoogleCalendar(eventId));
        }

        [HttpDelete("Delete/{eventId}")]
        public async Task<IActionResult> DeleteEventGoogleCalendar(string eventId)
        {
            return Ok(await EventosGoogleAgendaService.DeleteEventGoogleCalendar(eventId));
        }

        [HttpPost("Update/{eventId}")]
        public async Task<IActionResult> UpdateEventGoogleCalendar(string eventId)
        {
            return Ok(await EventosGoogleAgendaService.UpdateEventGoogleCalendar(eventId));
        }
    }
}
