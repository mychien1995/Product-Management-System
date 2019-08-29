using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductMS.DataAccess.SqlServer.Entities
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }
        public string LanguageCode { get; set; }
    }
}
