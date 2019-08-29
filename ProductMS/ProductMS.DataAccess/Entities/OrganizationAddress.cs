using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductMS.DataAccess.SqlServer.Entities
{
    public class OrganizationAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrganizationAddressId { get; set; }
        public int OrganizationId { get; set; }
        public int AddressId { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Organization { get; set; }
        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }
        public bool IsPrimary { get; set; }
    }
}
