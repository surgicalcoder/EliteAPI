using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ProspectedAsteroidInfo
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Materials")]
        public List<ProspectedMaterial> Materials { get; set; }

        [JsonProperty("MotherlodeMaterial")]
        public string MotherlodeMaterial { get; set; }

        [JsonProperty("MotherlodeMaterial_Localised")]
        public string MotherlodeMaterialLocalised { get; set; }

        [JsonProperty("Content")]
        public string Content { get; set; }

        [JsonProperty("Content_Localised")]
        public string ContentLocalised { get; set; }

        [JsonProperty("Remaining")]
        public long Remaining { get; set; }

        internal static ProspectedAsteroidInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeProspectedAsteroidEvent(JsonConvert.DeserializeObject<ProspectedAsteroidInfo>(json, JsonSettings.Settings));
        }
    }
}