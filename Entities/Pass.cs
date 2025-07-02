using System.Text.Json.Serialization;

namespace InterfaceDB.Entities
{
    public class Pass : BaseEntity
    {
        [JsonPropertyName("user_id")]
        public int user_id { get; set; }
        [JsonPropertyName("type_id")]
        public int type_id { get; set; }
        public int is_active { get; set; }
    }
}
