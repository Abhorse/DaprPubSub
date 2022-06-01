namespace Infrastructure.Contract
{
    public interface IDaprInfrastructure
    {
        Task PublishTopic<T>(string pubsub, string topic, T body);
        Task<T> ServiceCallByDapr<T>(HttpMethod httpMethod, string appId, string endPoint, dynamic body);
    }
}