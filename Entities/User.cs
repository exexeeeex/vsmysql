using System.Text.Json.Serialization;

namespace InterfaceDB.Entities
{
    public class User : BaseEntity
    {
        [JsonPropertyName("first_name")]
        public string first_name { get; set; } = null!;
        [JsonPropertyName("last_name")]
        public string last_name { get; set; } = null!;
        [JsonPropertyName("department_id")]
        public int department_id { get; set; }
    }
}
