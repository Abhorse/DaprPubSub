namespace Infrastructure.Contract
{
    public interface IDaprInfrastructure
    {
        Task PublishTopic(string pubsub, string topic, dynamic body);
        Task<T> ServiceCallByDapr<T>(HttpMethod httpMethod, string appId, string endPoint, dynamic body);
    }
}