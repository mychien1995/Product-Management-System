using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Models.Interfaces
{
    public interface IDisableable
    {
        bool IsActive { get; set; }
    }
}
