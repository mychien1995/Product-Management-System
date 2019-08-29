using ProductMS.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Models
{
    public class OrganizationModel : IDisableable, IPreservable, IChangeTrackable
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }

        public string CMSHostNames { get; set; }
        public string WebHostNames { get; set; }

        public int ProvinceId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
