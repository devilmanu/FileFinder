using FileFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileFinder.AppServices.Files.Queries.GetFileByText
{
    public class FileFindByTextResponse
    {
        public Guid Id { get; set; }
        public IEnumerable<string> Highlights { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
