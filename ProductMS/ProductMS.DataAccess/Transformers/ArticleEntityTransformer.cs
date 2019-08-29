using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.Framework.IoC;
using ProductMS.Models;
using ProductMS.Services.Abstractions;

namespace ProductMS.DataAccess.SqlServer
{
    [ServiceTypeOf(typeof(IModelTransformer<ArticleModel, Article>))]
    public class ArticleEntityTransformer : IModelTransformer<ArticleModel, Article>
    {
        public Article ToProviderData(ArticleModel model)
        {
            if (model == null) return null;
            return new Article()
            {

                ArticleId = model.ArticleId,
                Title = model.Title,
                Summary = model.Summary,
                Content = model.Content,
                ThumbnailUrl = model.ThumbnailUrl,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate,
                PublishedDate = model.PublishedDate,
                CreatedBy = model.CreatedBy,
                UpdatedBy = model.UpdatedBy,
                IsPublished = model.IsPublished,
                IsDeleted = model.IsDeleted,
            };
        }

        public ArticleModel ToModel(Article entity)
        {
            if (entity == null || !(entity is Article)) return null;
            var product = (Article)entity;
            return new ArticleModel()
            {

                ArticleId = entity.ArticleId,
                Title = entity.Title,
                Summary = entity.Summary,
                Content = entity.Content,
                ThumbnailUrl = entity.ThumbnailUrl,
                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate,
                PublishedDate = entity.PublishedDate,
                CreatedBy = entity.CreatedBy,
                UpdatedBy = entity.UpdatedBy,
                IsPublished = entity.IsPublished,
                IsDeleted = entity.IsDeleted
            };
        }
    }
}

