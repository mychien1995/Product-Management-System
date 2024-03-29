﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductMS.DataAccess.SqlServer.Entities
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual Province Province { get; set; }
        public virtual List<Address> Addresses { get; set; }
    }
}
