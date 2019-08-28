using ProductMS.Models.Articles;
using ProductMS.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Services.Articles
{
    public interface IArticleService : IModelService<ArticleModel>
    {

    }
    public class ArticleService : BaseModelService<ArticleModel>, IArticleService
    {
        private readonly IArticleDataProvider _provider;
        public ArticleService(IArticleDataProvider provider) : base(provider)
        {
            _provider = provider;
        }
    }
}

