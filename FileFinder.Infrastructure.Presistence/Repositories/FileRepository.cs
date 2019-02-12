using FileFinder.Domain.Entities;
using FileFinder.Domain.Repositories;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileFinder.Infrastructure.Presistence.Elastic.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly IElasticClient _elasticClient;

        public FileRepository(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public void IndexFile(Document file)
        {
            var response = _elasticClient.Index(file, i => i.Index($"file-app-{file.UploadAt.Year}")
                                                            .Pipeline("attachments"));
        }

        public IEnumerable<Document> SearchFileByContent(string content)
        {
            var searchResponse = _elasticClient.Search<Document>(s => s
              .Query(q => q
                .Match(m => m
                  .Field(a => a.Attachment.Content)
                  .Query(content)
                )
              )
            );
            return searchResponse.Hits.Select(o => o.Source);
        }


        public IEnumerable<Document> SearchHighlightFileByContent(string content)
        {
            var searchResponse = _elasticClient.Search<Document>(s => s
                .Highlight(h => h
                    .Order(HighlighterOrder.Score)
                    .PreTags("<b>")
                    .PostTags("</b>")
                    .Fields(fs => fs
                        .Field(f => f.Attachment.Content)
                    )
                )
                .Query(q => q
                .Match(m => m
                  .Field(a => a.Attachment.Content)
                  .Query(content)
                  .MinimumShouldMatch("100%")
                  .Operator(Operator.And)
                  .Fuzziness(Fuzziness.Auto)
                )

              //.MatchPhrasePrefix(mp => mp
              //    .Query(content)
              //    )
              )
            );

            return searchResponse.Hits.Select(o => new Document {
                Highlights = o.Highlights.FirstOrDefault(h => h.Key == "attachment.content").Value?.Highlights,
                Attachment = o.Source.Attachment,
                Content = o.Source.Content,
                Id = o.Source.Id,
                UploadAt = o.Source.UploadAt,
                ImageUrl = o.Source.ImageUrl                
            });
        }
    }
}
