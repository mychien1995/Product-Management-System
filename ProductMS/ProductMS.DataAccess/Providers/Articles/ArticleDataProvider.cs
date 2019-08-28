using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.DataAccess.SqlServer.Repositories;
using ProductMS.Models.Articles;
using ProductMS.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.DataAccess.SqlServer.Providers
{
    public class ArticleDataProvider : BaseEntityDataProvider<ArticleModel, Article>, IArticleDataProvider
    {
        private readonly IArticleRepository _repository;
        public ArticleDataProvider(IArticleRepository repository, IModelTransformer<ArticleModel, Article> transformer)
            : base(repository, transformer)
        {
            _repository = repository;
        }
    }
}

