using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductMS.DataAccess.SqlServer.Entities
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Summary { get; set; }
        public string Content { get; set; }

        public string ThumbnailUrl { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime? PublishedDate { get; set; }

        public string CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual ApplicationUser CreatedByUser { get; set; }

        public string UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy")]
        public virtual ApplicationUser UpdatedByUser { get; set; }

        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }

    }
}
