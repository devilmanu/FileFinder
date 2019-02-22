using FileFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileFinder.Domain.Repositories
{
    public interface IFileRepository
    {
        IEnumerable<Document> SearchFileByContent(string content);
        void IndexFile(Document file);
        IEnumerable<Document> SearchHighlightFileByContent(string content);
        long GetCountOfDocuments();
    }
}
