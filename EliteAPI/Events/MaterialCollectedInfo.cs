using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class MaterialCollectedInfo : EventBase
    {
        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static MaterialCollectedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeMaterialCollectedEvent(JsonConvert.DeserializeObject<MaterialCollectedInfo>(json, JsonSettings.Settings));
        }
    }
}