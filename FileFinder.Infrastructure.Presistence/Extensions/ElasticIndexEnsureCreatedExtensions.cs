using FileFinder.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileFinder.Infrastructure.Presistence.Elastic.Extensions
{
    public static class ElasticIndexEnsureCreatedExtensions
    {
        public static IWebHost ElasticIndexEnsureCreated(this IWebHost webHost)
        {
            var scope = webHost.Services.CreateScope();
            var client = scope.ServiceProvider.GetService<IElasticClient>();
            var logger = scope.ServiceProvider.GetService<ILogger<ElasticClient>>();

            if (!client.IndexTemplateExists("file-template").Exists)
            {
                CreateIndexTodoAppTemplate(client);
            };
            return webHost;
        }

        private static void CreateIndexTodoAppTemplate(IElasticClient elasticClient)
        {
            var putIndexTemplateResponse = elasticClient.PutIndexTemplate("file-template", tem => tem
                                                              .IndexPatterns("file-app-*")
                                                              .Mappings(m => m
                                                                .Map<Document>(mp => mp
                                                                  .AutoMap()
                                                                  .AllField(all => all
                                                                    .Enabled(false)
                                                                  )
                                                                )
                                                              )
                                                            );

            elasticClient.PutPipeline("attachments", p => p
                          .Description("Document attachment pipeline")
                          .Processors(pr => pr
                            .Attachment<Document>(a => a
                              .Field(f => f.Content)
                              .TargetField(f => f.Attachment)
                            )
                            .Remove<Document>(r => r
                              .Field(f => f.Content)
                            )
                          )
                        );

            if (!putIndexTemplateResponse.IsValid)
                throw new Exception($"Error to create IndexTemplate {putIndexTemplateResponse.ServerError.Error.StackTrace}");
        }
    }
}
