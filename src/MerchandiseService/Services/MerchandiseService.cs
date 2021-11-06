using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Services
{
    public interface IMerchandiseService
    {
        ValueTask GetMerchandiseInfo(CancellationToken ct);
        ValueTask GiveOutMerchandise(CancellationToken ct);
    }
    public class MerchandiseService : IMerchandiseService
    {
        public async ValueTask GetMerchandiseInfo(CancellationToken ct)
        {}
        
        public async ValueTask GiveOutMerchandise(CancellationToken ct)
        { }
    }
}