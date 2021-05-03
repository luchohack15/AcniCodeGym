using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymNicaCode_Persistencia;
using GymNicaCode_Dominio;

namespace GymNicaCode_APP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly GymNicaCodeContext context;
        public WeatherForecastController (GymNicaCodeContext _context)
        {
            this.context = _context;

        }
        

        [HttpGet]
        public IEnumerable<Empleado> Get()
        {
            return context.Empleados.ToList();
            
        }
    }
}
