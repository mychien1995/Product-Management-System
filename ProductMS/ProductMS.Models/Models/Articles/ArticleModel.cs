using ProductMS.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Models.Articles
{
    public class ArticleModel : IChangeTrackable, IPreservable
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }

        public string Summary { get; set; }
        public string Content { get; set; }

        public string ThumbnailUrl { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime? PublishedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
    }
}
