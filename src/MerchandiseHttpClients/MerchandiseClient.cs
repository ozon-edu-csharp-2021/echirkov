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
            CancellationToken ct);
        Task<GiveOutMerchandiseResponse> GiveOutMerchandise(GiveOutMerchandiseRequest giveOutMerchandiseRequest,
            CancellationToken ct);
    }
    
    public class MerchandiseClient : IMerchandiseClient
    {
        private readonly HttpClient _httpClient;

        public MerchandiseClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetMerchandiseInfoResponse> GetMerchandiseInfo(GetMerchandiseInfoRequest merchandiseInfoRequest,
            CancellationToken ct)
        {
            var json = JsonSerializer.Serialize(merchandiseInfoRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            using var response = await _httpClient.PostAsync("/api/v1.0/Merchandise/GetInfo", content, ct);
            var body = await response.Content.ReadAsStringAsync(ct);
            return JsonSerializer.Deserialize<GetMerchandiseInfoResponse>(body);
        }
        
        public async Task<GiveOutMerchandiseResponse> GiveOutMerchandise(GiveOutMerchandiseRequest giveOutMerchandiseRequest,
            CancellationToken ct)
        {
            var json = JsonSerializer.Serialize(giveOutMerchandiseRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            using var response = await _httpClient.PostAsync("/api/v1.0/Merchandise/GiveOut", content, ct);
            var body = await response.Content.ReadAsStringAsync(ct);
            return JsonSerializer.Deserialize<GiveOutMerchandiseResponse>(body);
        }
    }
}