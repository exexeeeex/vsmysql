using System.Text.Json.Serialization;

namespace InterfaceDB.Entities
{
    public class PassType : BaseEntity
    {
        [JsonPropertyName("name")]
        public string name { get; set; } = null!;
    }
}
