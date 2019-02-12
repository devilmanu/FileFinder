using FileFinder.Domain.Entities;
using FileFinder.Domain.Repositories;
using FileFinder.Infrastructure.Bus.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileFinder.AppServices.Files.Queries.GetFileByText
{
    public class GetFileByTextQueryHandler : IQueryHandler<GetFileByTextQuery, IEnumerable<FileFindByTextResponse>>
    {
        private readonly IFileRepository _fileRepository;

        public GetFileByTextQueryHandler(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public Task<IEnumerable<FileFindByTextResponse>> Handle(GetFileByTextQuery request, CancellationToken cancellationToken)
        {
            var result = _fileRepository.SearchHighlightFileByContent(request.Content).Select(o => new FileFindByTextResponse
            {
                Highlights = o.Highlights,
                Id = o.Id,
                Title = o.Attachment.Title,
                ImageUrl = o.ImageUrl
            });
            return Task.FromResult(result);
        }
    }
}
