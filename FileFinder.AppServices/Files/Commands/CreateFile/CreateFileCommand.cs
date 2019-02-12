using FileFinder.Infrastructure.Bus.Commands;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileFinder.AppServices.Files.Commands.CreateFile
{
    public class CreateFileCommand : ICommand
    {
        public CreateFileCommand(Guid id, string imageUrl, IFormFile file)
        {
            Id = id;
            File = file;
            ImageUrl = imageUrl;
        }

        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile File { get; set; }
    }
}
