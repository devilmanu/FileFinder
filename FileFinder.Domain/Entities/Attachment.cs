using System;
using System.Collections.Generic;
using System.Text;

namespace FileFinder.Domain.Entities
{
    public class Attachment
    {
        public string Author { get; set; }
        public bool ContainsMetadata { get; }
        public string Content { get; set; }
        public long? ContentLength { get; set; }
        public string ContentType { get; set; }
        public DateTime? Date { get; set; }
        public bool? DetectLanguage { get; set; }
        public long? IndexedCharacters { get; set; }
        public string Keywords { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }
}
