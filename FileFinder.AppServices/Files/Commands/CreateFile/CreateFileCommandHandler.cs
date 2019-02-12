using FileFinder.Domain.Entities;
using FileFinder.Domain.Repositories;
using FileFinder.Infrastructure.Bus.Commands;
using iTextSharp.text.pdf;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileFinder.AppServices.Files.Commands.CreateFile
{
    public class CreateFileCommandHandler : ICommandHandler<CreateFileCommand>
    {
        private readonly IFileRepository _fileRepository;

        public CreateFileCommandHandler(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }


        public Task<Unit> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            string content;
            using (var ms = new MemoryStream())
            {
                request.File.CopyTo(ms);
                var fileBytes = ms.ToArray();
                content = Convert.ToBase64String(fileBytes);
            }

            var fileToInsert = new Document
            {
                Id = request.Id,
                Content = content,
                ImageUrl = request.ImageUrl,
                UploadAt = DateTimeOffset.Now,
                Attachment = new Attachment
                {
                    Name = request.File.Name
                }
            };
            _fileRepository.IndexFile(fileToInsert);
            return Task.FromResult(new Unit());
        }

    }



}
