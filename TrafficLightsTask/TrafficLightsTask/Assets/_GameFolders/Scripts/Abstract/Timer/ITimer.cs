namespace TrafficLightAssesment.Abstract.Timer
{
    public interface ITimer
    {
        bool TimerFinished { get; }
        void CountDown();
        void StartTimer();
        void ResetTimer();
    }
}