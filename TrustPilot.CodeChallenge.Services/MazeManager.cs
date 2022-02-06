using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrustPilot.CodeChallenge.Models;
using TrustPilot.CodeChallenge.Models.Enums;
using TrustPilot.CodeChallenge.Services.Interfaces;

namespace TrustPilot.CodeChallenge.Services
{
    public class MazeManager : IMazeManager
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MazeManager> _logger;

        public MazeManager(IHttpClientFactory httpClientFactory, ILogger<MazeManager> logger)
        {
            _httpClient = httpClientFactory.CreateClient("maze");
            _logger = logger;
        }

        public async Task<CreateMazeResponse> CreateMaze(CreateMazeRequest createMazeRequest)
        {
            var payload = JsonConvert.SerializeObject(createMazeRequest);

            var createMazeResponse = await _httpClient.SendAsync(new HttpRequestMessage
            {
                RequestUri = new Uri("pony-challenge/maze", UriKind.Relative),
                Method = HttpMethod.Post,
                Content = new StringContent(payload, Encoding.UTF8, "application/json")
            });

            try
            {
                createMazeResponse.EnsureSuccessStatusCode();

                var responseContent = await createMazeResponse.Content.ReadAsStringAsync();

                var response = JsonConvert.DeserializeObject<CreateMazeResponse>(responseContent);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex);
                throw ex;
            }
        }

        public async Task<GetMazeResponse> GetMazeById(string mazeId)
        {
            var getMazeResponse = await _httpClient.SendAsync(new HttpRequestMessage
            {
                RequestUri = new Uri($"pony-challenge/maze/{mazeId}", UriKind.Relative),
                Method = HttpMethod.Get
            });

            try
            {
                getMazeResponse.EnsureSuccessStatusCode();

                var response = await getMazeResponse.Content.ReadAsStringAsync();

                var finalResponse = JsonConvert.DeserializeObject<GetMazeResponse>(response);

                return finalResponse;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex.Message, ex);
                throw ex;
            }
        }

        public async Task<MovePonyResponse> MovePony(string mazeId, MoveDirection moveDirection)
        {
            var movePonyRequest = new MovePonyRequest
            {
                Direction = moveDirection
            };

            var serializedMovePonyRequest = JsonConvert.SerializeObject(movePonyRequest);

            var movePonyResponse = await _httpClient.SendAsync(new HttpRequestMessage
            {
                RequestUri = new Uri($"pony-challenge/maze/{mazeId}", UriKind.Relative),
                Method = HttpMethod.Post,
                Content = new StringContent(serializedMovePonyRequest, Encoding.UTF8, "application/json")
            });

            try
            {
                movePonyResponse.EnsureSuccessStatusCode();

                var response = await movePonyResponse.Content?.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MovePonyResponse>(response);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex);
                throw ex;
            }
        }

        public async Task<string> PrintMaze(string mazeId)
        {
            if (string.IsNullOrEmpty(mazeId))
            {
                throw new ArgumentNullException($"{nameof(mazeId)}");
            }

            var printMazeResponse = await _httpClient.SendAsync(new HttpRequestMessage
            {
                RequestUri = new Uri($"pony-challenge/maze/{mazeId}/print", UriKind.Relative),
                Method = HttpMethod.Get
            });

            try
            {
                printMazeResponse.EnsureSuccessStatusCode();
                return await printMazeResponse.Content?.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex);
                throw ex;
            }
        }
    }
}
