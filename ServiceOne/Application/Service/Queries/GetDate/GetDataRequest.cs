using MediatR;

namespace Application.Service.Queries.GetData
{
    public class GetDataRequest : IRequest<GetDataResponse>
    {
        public int Id { get; set; }
    }
}