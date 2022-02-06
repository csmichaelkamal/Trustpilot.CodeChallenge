using Newtonsoft.Json;

namespace TrustPilot.CodeChallenge.Models
{
    public class CreateMazeResponse
    {
        [JsonProperty("maze_id")]
        public string MazeId { get; set; }
    }
}
