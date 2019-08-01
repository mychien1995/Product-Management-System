using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Models.Interfaces
{
    public interface IChangeTrackable
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
