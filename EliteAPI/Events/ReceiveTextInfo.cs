using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ReceiveTextInfo : EventBase
    {
        [JsonProperty("From")]
        public string From { get; internal set; }

        [JsonProperty("From_Localised")]
        public string FromLocalised { get; internal set; }

        [JsonProperty("Message")]
        public string Message { get; internal set; }

        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; internal set; }

        [JsonProperty("Channel")]
        public string Channel { get; internal set; }

        internal static ReceiveTextInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeReceiveTextEvent(JsonConvert.DeserializeObject<ReceiveTextInfo>(json, JsonSettings.Settings));
        }
    }
}