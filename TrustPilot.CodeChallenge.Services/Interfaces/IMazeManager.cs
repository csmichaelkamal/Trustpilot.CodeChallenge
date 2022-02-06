using System.Threading.Tasks;
using TrustPilot.CodeChallenge.Models;
using TrustPilot.CodeChallenge.Models.Enums;

namespace TrustPilot.CodeChallenge.Services.Interfaces
{
    public interface IMazeManager
    {
        Task<CreateMazeResponse> CreateMaze(CreateMazeRequest createMazeRequest);
        
        Task<GetMazeResponse> GetMazeById(string mazeId);
        
        Task<MovePonyResponse> MovePony(string mazeId, MoveDirection moveDirection);
        
        Task<string> PrintMaze(string mazeId);
    }
}
