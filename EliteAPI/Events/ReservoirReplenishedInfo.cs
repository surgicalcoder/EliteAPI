﻿using System;
using Newtonsoft.Json;

namespace EliteAPI.Events
{
    public class ReservoirReplenishedInfo : EventBase
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("FuelMain")]
        public double FuelMain { get; set; }

        [JsonProperty("FuelReservoir")]
        public double FuelReservoir { get; set; }

        internal static ReservoirReplenishedInfo Process(string json, EliteDangerousAPI api)
        {
            return api.Events.InvokeReservoirReplenishedEvent(JsonConvert.DeserializeObject<ReservoirReplenishedInfo>(json, JsonSettings.Settings));
        }
    }
}