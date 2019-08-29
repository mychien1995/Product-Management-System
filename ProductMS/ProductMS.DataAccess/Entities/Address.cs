using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductMS.DataAccess.SqlServer.Entities
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }

        public string AddressLine { get; set; }
        public int CountryId { get; set; }
        public int ProvinceId { get; set; }
        public int? DistrictId { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }
        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        public virtual List<OrganizationAddress> Organizations { get; set; }
    }
}
