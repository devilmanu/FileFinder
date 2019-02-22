using FileFinder.AppServices.Files.Queries.GetCount;
using FileFinder.Domain.Entities;
using FileFinder.Domain.Repositories;
using FileFinder.Infrastructure.Bus.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileFinder.AppServices.Files.Queries.GetCount
{
    public class GetDocumentCountQueryHandler : IQueryHandler<GetDocumentCountQuery, DocumentCountResponse>
    {
        private readonly IFileRepository _fileRepository;

        public GetDocumentCountQueryHandler(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public Task<DocumentCountResponse> Handle(GetDocumentCountQuery request, CancellationToken cancellationToken)
        {
            var result = _fileRepository.GetCountOfDocuments();
            return Task.FromResult(new DocumentCountResponse
            {
                Count = result
            });
        }
    }
}
