using Infrastructure.Contract;
using Dapr.Client;

namespace Infrastructure.Persistence.Dapr
{
    public class DaprInfrastructure : IDaprInfrastructure
    {
        public async Task PublishTopic<T>(string pubsub, string topic, T body)
        {
            var daprClient = new DaprClientBuilder().Build();
            if (body == null)
            {
                await daprClient.PublishEventAsync(pubsub, topic, body);
            }
            else
            {
                await daprClient.PublishEventAsync(pubsub, topic);

            }
        }


        public async Task<T> ServiceCallByDapr<T>(HttpMethod httpMethod, string appId, string endPoint, dynamic body)
        {
            var daprClient = new DaprClientBuilder().Build();
            HttpRequestMessage requestMessage;
            if (body == null)
            {
                requestMessage = daprClient.CreateInvokeMethodRequest(httpMethod, appId, endPoint);
            }
            else
            {
                requestMessage = daprClient.CreateInvokeMethodRequest(httpMethod, appId, endPoint, body);
            }

            var result = await daprClient.InvokeMethodAsync<T>(requestMessage);
            return result;
        }
    }
}