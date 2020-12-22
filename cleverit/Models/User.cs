using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace cleverit.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("apellido")]
        public string Apellido { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("profesion")]
        public string Profesion { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}