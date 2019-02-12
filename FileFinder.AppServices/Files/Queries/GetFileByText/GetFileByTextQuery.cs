using FileFinder.Domain.Entities;
using FileFinder.Infrastructure.Bus.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileFinder.AppServices.Files.Queries.GetFileByText
{
    public class GetFileByTextQuery : IQuery<IEnumerable<FileFindByTextResponse>>
    {
        public GetFileByTextQuery(string content)
        {
            Content = content;
        }

        public string Content { get; set; }
    }
}
