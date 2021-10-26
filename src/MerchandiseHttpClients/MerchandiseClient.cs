using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseHttpModels;

namespace MerchandiseHttpClients
{
    public interface IMerchandiseClient
    {
        Task<GetMerchandiseInfoResponse> GetMerchandiseInfo(GetMerchandiseInfoRequest merchandiseInfoRequest,
            CancellationToken token);
        Task<GiveOutMerchandiseResponse> GiveOutMerchandise(GiveOutMerchandiseRequest giveOutMerchandiseRequest,
            CancellationToken token);
    }
    
    public class MerchandiseClient : IMerchandiseClient
    {
        private readonly HttpClient _httpClient;

        public MerchandiseClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetMerchandiseInfoResponse> GetMerchandiseInfo(GetMerchandiseInfoRequest merchandiseInfoRequest,
            CancellationToken token)
        {
            var json = JsonSerializer.Serialize(merchandiseInfoRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            using var response = await _httpClient.PostAsync("/api/v1.0/Merchandise/GetInfo", content, token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<GetMerchandiseInfoResponse>(body);
        }
        
        public async Task<GiveOutMerchandiseResponse> GiveOutMerchandise(GiveOutMerchandiseRequest giveOutMerchandiseRequest,
            CancellationToken token)
        {
            var json = JsonSerializer.Serialize(giveOutMerchandiseRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            using var response = await _httpClient.PostAsync("/api/v1.0/Merchandise/GiveOut", content, token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<GiveOutMerchandiseResponse>(body);
        }
    }
}