using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductMS.DataAccess.SqlServer.Entities
{
    public class LocalizedProperty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocalizedPropertyId { get; set; }

        public string Key { get; set; }
        public string Value { get; set; }

        public string LanguageCode { get; set; }
    }
}
