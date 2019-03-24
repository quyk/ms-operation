using Newtonsoft.Json;

namespace MS.Operation.Domain.Entities
{
    public class Account
    {
        [JsonProperty("number")]
        public int Number { get; set; }
        [JsonProperty("balance", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double Balance { get; set; }
        public bool Limit { get; set; }
    }
}
