using System;

namespace ProductMS.Models.Interfaces
{
    public interface IChangeTrackable
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
