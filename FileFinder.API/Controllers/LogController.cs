using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        // POST: api/Log
        [HttpPost]
        public void Post([FromBody] ErrorLog error)
        {
            throw new FieldAccessException(error.Description);
        }
    }

    public class ErrorLog
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
