using Newtonsoft.Json;

namespace TrustPilot.CodeChallenge.Models
{
    public class MazeState
    {
        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("state-result")]
        public string StateResult { get; set; }
    }
}
