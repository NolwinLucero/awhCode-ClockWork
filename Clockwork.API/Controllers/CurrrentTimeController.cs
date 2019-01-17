using System;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;
using System.Linq;
using System.Collections.Generic;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class CurrentTimeController : Controller
    {
        // GET api/currenttime


        [HttpPost]
        public IActionResult Post([FromBody]string timeZone)
        {
            var utcTime = DateTime.UtcNow;
            var serverTime = DateTime.Now;
            var ip = this.HttpContext.Connection.RemoteIpAddress.ToString();
            var tzi = TimeZoneInfo.GetSystemTimeZones().SingleOrDefault(t => t.DisplayName.Equals(timeZone));

            var returnVal = new CurrentTimeQuery
            {
                UTCTime = utcTime,
                ClientIp = ip,
                Time = serverTime,
                Timezone = timeZone,
                TimezoneTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi)
        };

            using (var db = new ClockworkContext())
            {
                db.CurrentTimeQueries.Add(returnVal);
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);

                Console.WriteLine();
                foreach (var CurrentTimeQuery in db.CurrentTimeQueries)
                {
                    Console.WriteLine(" - {0}", CurrentTimeQuery.UTCTime);
                }
            }

            return Ok(returnVal);
        }

        // GET api/currenttime
        [HttpGet]
        public IActionResult Get()
        {
            using (var db = new ClockworkContext())
            {
                return new ObjectResult(db.CurrentTimeQueries.ToList());
            }                           
        }
    }
}
