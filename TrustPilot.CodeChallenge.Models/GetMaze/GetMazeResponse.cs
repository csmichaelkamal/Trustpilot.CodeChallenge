using Newtonsoft.Json;
using System.Collections.Generic;

namespace TrustPilot.CodeChallenge.Models
{
    public class GetMazeResponse
    {
        [JsonProperty("pony")]
        public int[] Pony { get; set; }

        [JsonProperty("domokun")]
        public int[] Domokun { get; set; }

        [JsonProperty("end-point")]
        public int[] EndPoint { get; set; }

        [JsonProperty("size")]
        public int[] Size { get; set; }

        [JsonProperty("difficulty")]
        public int Difficulty { get; set; }

        [JsonProperty("data")]
        public string[][] Data { get; set; }

        [JsonProperty("maze_id")]
        public string MazeId { get; set; }

        [JsonProperty("maze-state")]
        public MazeState MazeState { get; set; }
    }
}
