namespace TrafficLightAssesment.Abstract.Mediator
{
    public interface IMediator<T>
    {
        void Notify(T sender);
        void Register(T participant);
    }
    
}
