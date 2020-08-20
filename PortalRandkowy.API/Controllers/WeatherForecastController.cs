using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortalRandkowy.API.Data;
using PortalRandkowy.API.Dtos;
using PortalRandkowy.API.Models;

namespace PortalRandkowy.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _context;
        public WeatherForecastController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
         var values = _context.Values.ToList();
         return Ok(values);
        }
    }
}
