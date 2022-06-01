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
                new GetDataResponse { Id = 3, Name = "Aashish Bhorse"},
                new GetDataResponse { Id = 4, Name = "AB"},
                new GetDataResponse { Id = 5, Name = "ABhorse"},
                new GetDataResponse { Id = 6, Name = "269"},
                new GetDataResponse { Id = 7, Name = "1669"},
            };
            var result = list.FirstOrDefault(x => x.Id == request.Id);

            await _daprInfrastructure.PublishTopic("pubsub", "UpdateData", result);

            return result;
        }
    }
}