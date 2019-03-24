using Newtonsoft.Json;

namespace MS.Operation.Domain.Entities
{
    public class Transfer
    {
        [JsonProperty("origin")]
        public Account Origin { get; set; }
        [JsonProperty("destination")]
        public Account Destination { get; set; }
        [JsonProperty("value")]
        public float Value { get; set; }
    }
}
