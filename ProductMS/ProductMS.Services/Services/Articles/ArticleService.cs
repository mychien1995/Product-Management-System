using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.DataAccess.SqlServer.Repositories;
using ProductMS.Models;
using ProductMS.Services.Abstractions;

namespace ProductMS.Services
{
    public interface IArticleService : IModelService<ArticleModel>
    {

    }
    public class ArticleService : BaseModelService<ArticleModel, Article>, IArticleService
    {
        private readonly IArticleRepository _repository;
        public ArticleService(IArticleRepository repository, IModelTransformer<ArticleModel, Article> transformer) : base(repository, transformer)
        {
            _repository = repository;
        }
    }
}
