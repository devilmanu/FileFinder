using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileFinder.Domain.Entities
{
    public class Document
    {
        public Guid Id { get; set; }
        public DateTimeOffset UploadAt { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public Attachment Attachment { get; set; }
        public IEnumerable<string> Highlights { get; set; }
    }
}
