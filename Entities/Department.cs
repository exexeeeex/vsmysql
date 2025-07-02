using System.Text.Json.Serialization;

namespace InterfaceDB.Entities
{
    public class Department : BaseEntity
    {
        [JsonPropertyName("name")]
        public string name { get; set; } = null!;
        [JsonPropertyName("start_work_time")]
        public TimeSpan start_work_time { get; set; }
        [JsonPropertyName("end_work_time")]
        public TimeSpan end_work_time { get; set; } 
    }
}
