using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VolvoCleaner.Web.Frontend.Models
{
    public class NameGenderModel
    {
        public List<NameGenderItem> Names { get; set; }
    }

    public class NameGenderItem
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Name { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }
    }
}
