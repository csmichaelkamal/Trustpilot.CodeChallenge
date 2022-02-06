using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TrustPilot.CodeChallenge.Models
{
    public class CreateMazeRequest
    {
        [JsonProperty("maze-height")]
        [Range(15, 25)]
        public int MazeHeight { get; set; }

        [JsonProperty("maze-width")]
        [Range(15, 25)]
        public int MazeWidth { get; set; }

        [JsonProperty("maze-player-name")]
        public string PlayerName { get; set; }

        [JsonProperty("difficulty")]
        [Range(0, 10)]
        public int Difficulty { get; set; }
    }
}
