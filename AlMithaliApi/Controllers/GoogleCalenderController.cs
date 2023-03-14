using Application.Interface;
using Domain.Codes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlMithaliApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleCalenderController : ControllerBase
    {

        readonly IGoogleCalender _googleCalender;
        public GoogleCalenderController(IGoogleCalender googleCalender)
        {
            _googleCalender = googleCalender;
        }

        [HttpGet("GetEvents")]
        public  Task<IActionResult> GetEvents()
        {
            return Ok( _googleCalender.GetEvents());
        }

        [HttpDelete("DeleteEvent/{code}")]
        public Task<IActionResult> DeleteEvent(string code)
        {
            return Ok(_googleCalender.DeleteEvent(code));
        }


        [HttpPost("Insert")]
        public Task<IActionResult> Insert(CalenderEvents calenderEvents)
        {
            return Ok(_googleCalender.Insert(calenderEvents));
        }
    }
}
