using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductMS.DataAccess.SqlServer.Entities
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        public string CountryCode { get; set; }
        public string Name { get; set; }

        public virtual List<Province> Provinces { get; set; }

        public virtual List<Address> Addresses { get; set; }
    }
}
