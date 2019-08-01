using ProductMS.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Models.Products
{
    public class ProductModel : IChangeTrackable, IPreservable
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
    }
}
