using Newtonsoft.Json;

namespace TrustPilot.CodeChallenge.API.Models
{
    public class CreateMazeModel
    {
        [JsonProperty("maze-height")]
        public int MazeHeight { get; set; }

        [JsonProperty("maze-width")]
        public int MazeWidth { get; set; }

        [JsonProperty("maze-player-name")]
        public string PlayerName { get; set; }

        [JsonProperty("difficulty")]
        public int Difficulty { get; set; }
    }
}
