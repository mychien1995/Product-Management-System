using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Models.Interfaces
{
    public interface IPreservable
    {
        bool IsDeleted { get; set; }
    }
}
