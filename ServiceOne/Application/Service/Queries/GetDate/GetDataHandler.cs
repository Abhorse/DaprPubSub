using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Infrastructure.Contract;

namespace Application.Service.Queries.GetData
{
    public class GetDataHandler : IRequestHandler<GetDataRequest, GetDataResponse>
    {
        private readonly IDaprInfrastructure _daprInfrastructure;

        public GetDataHandler(IDaprInfrastructure daprInfrastructure)
        {
            _daprInfrastructure = daprInfrastructure;
        }

        public async Task<GetDataResponse> Handle(GetDataRequest request, CancellationToken cancellationToken)
        {
            var list = new List<GetDataResponse>
            {
                new GetDataResponse { Id = 1, Name = "Aashish"},
                new GetDataResponse { Id = 2, Name = "Bhorse"},
            };
            var result = list.FirstOrDefault(x => x.Id == request.Id);

            await _daprInfrastructure.PublishTopic("pubsub", "myTopic", result);

            return result;
        }
    }
}