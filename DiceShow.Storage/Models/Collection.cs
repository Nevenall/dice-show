namespace DiceShow.Storage
{
    using Newtonsoft.Json;

    public class Collection
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}