using MediatR;

namespace ServiceTwo.Application.Service.Commands.UpdateData
{
    public class UpdateDataRequestModel : IRequest<UpdateDataResponseModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}