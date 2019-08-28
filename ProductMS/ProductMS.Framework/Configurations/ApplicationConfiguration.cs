using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductMS.Framework.Configurations
{
    public class ApplicationConfiguration
    {
        [JsonProperty("serviceInitializations")]
        public string[] ServiceInitializations { get; set; }
    }
}
