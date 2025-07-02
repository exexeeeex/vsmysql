using System.Text.Json.Serialization;

namespace InterfaceDB.Entities
{
    public class ActivationHistory : BaseEntity
    {
        [JsonPropertyName("pass_id")]
        public int pass_id { get; set; }
        [JsonPropertyName("date_time_activation")]
        public DateTime date_time_activation { get; set; }
    }
}
