namespace TrafficLightAssesment.Abstract.Mediator
{
    public interface IMediator<T>
    {
        void Notify(T sender, string eventMessage);
        void Register(T participant);
    }
    
}
