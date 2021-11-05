using System.Threading.Tasks;
using Grpc.Core;
using Merchandise.Grpc;
using MerchandiseService.Services;

namespace MerchandiseService.GrpcServices
{
    public class MerchandiseGrpcService : MerchandiseGrpc.MerchandiseGrpcBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseGrpcService(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }
        
        public override async Task<GetMerchandiseInfoResponse> GetMerchandiseInfo(GetMerchandiseInfoRequest request,
            ServerCallContext context)
        {
            await _merchandiseService.GetMerchandiseInfo(context.CancellationToken);
            return new GetMerchandiseInfoResponse();
        }

        public override async Task<GiveOutMerchandiseResponse> GiveOutMerchandise(GiveOutMerchandiseRequest request,
            ServerCallContext context)
        {
            await _merchandiseService.GiveOutMerchandise(context.CancellationToken);
            return new GiveOutMerchandiseResponse();
        }
    }
}