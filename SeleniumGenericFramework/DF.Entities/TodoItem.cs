using Newtonsoft.Json;

namespace DF.Entities
{
    public class TodoItem
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }
    }
}