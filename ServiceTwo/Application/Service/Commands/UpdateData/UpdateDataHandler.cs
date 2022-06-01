using MediatR;

namespace ServiceTwo.Application.Service.Commands.UpdateData
{
    public class UpdateDataHandler : IRequestHandler<UpdateDataRequestModel, UpdateDataResponseModel>
    {
        public async Task<UpdateDataResponseModel> Handle(UpdateDataRequestModel request, CancellationToken cancellationToken )
        {
            Console.WriteLine("############### Topic Subscribed #######################");
            Console.WriteLine(request);
            Console.WriteLine("############### Topic Subscribed #######################");

            return new UpdateDataResponseModel { Message = "Successfully recvied the topic"};
        }
    }
}