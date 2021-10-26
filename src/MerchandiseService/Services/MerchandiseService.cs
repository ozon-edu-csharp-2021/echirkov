using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Services
{
    public interface IMerchandiseService
    {
        ValueTask GetMerchandiseInfo(CancellationToken cancellationToken);
        ValueTask GiveOutMerchandise(CancellationToken cancellationToken);
    }
    public class MerchandiseService : IMerchandiseService
    {
        public async ValueTask GetMerchandiseInfo(CancellationToken cancellationToken)
        {}
        
        public async ValueTask GiveOutMerchandise(CancellationToken cancellationToken)
        { }
    }
}