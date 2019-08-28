using ProductMS.DataAccess.SqlServer.Databases;
using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.Models.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.DataAccess.SqlServer.Repositories
{
    public interface IArticleRepository : IEntityRepository<Article>
    {

    }

    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ProductDbContext context) : base(context)
        {

        }
    }
}

