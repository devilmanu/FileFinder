using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileFinder.AppServices.Files.Commands.CreateFile;
using FileFinder.AppServices.Files.Queries.GetFileByText;
using FileFinder.Infrastructure.Bus.Commands;
using FileFinder.Infrastructure.Bus.Queries;
using IronPdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public FileController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        // GET: api/File
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string content)
        {
            var respose = await _queryBus.Send(new GetFileByTextQuery(content));
            return Ok(respose);
        }

        // POST: api/File
        [HttpPost("{id}")]
        public async Task<IActionResult> Post(Guid id, [FromForm] string imageUrl, IFormFile file)
        {
            await _commandBus.Send(new CreateFileCommand(id, imageUrl, file));
            return Ok();
        }
    }
}
