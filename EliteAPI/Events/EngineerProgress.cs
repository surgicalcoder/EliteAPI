namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class EngineerProgressInfo
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("Engineers")]
        public List<Engineer> Engineers { get; set; }
    }

    public partial class Engineer
    {
        [JsonProperty("Engineer")]
        public string EngineerEngineer { get; set; }

        [JsonProperty("EngineerID")]
        public long EngineerId { get; set; }

        [JsonProperty("Progress")]
        public string Progress { get; set; }

        [JsonProperty("RankProgress", NullValueHandling = NullValueHandling.Ignore)]
        public long? RankProgress { get; set; }

        [JsonProperty("Rank", NullValueHandling = NullValueHandling.Ignore)]
        public long? Rank { get; set; }
    }

    public partial class EngineerProgressInfo
    {
        public static EngineerProgressInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeEngineerProgressEvent(JsonConvert.DeserializeObject<EngineerProgressInfo>(json, EliteAPI.Events.EngineerProgressConverter.Settings));
    }

    public static class EngineerProgressSerializer
    {
        public static string ToJson(this EngineerProgressInfo self) => JsonConvert.SerializeObject(self, EliteAPI.Events.EngineerProgressConverter.Settings);
    }

    internal static class EngineerProgressConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
