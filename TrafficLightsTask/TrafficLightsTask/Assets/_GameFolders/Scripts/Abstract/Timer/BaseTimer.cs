using TrafficLightAssesment.ScriptableObjects;
using UnityEngine;

namespace TrafficLightAssesment.Abstract.Timer
{
    public abstract class BaseTimer : ITimer
    {
        TrafficLightTimerSo _timerSo;
        float _timer;
        bool _canCountDown;
        protected float _maxTime;

        public bool TimerFinished => _timer <= 0;

        public BaseTimer(TrafficLightTimerSo timerSo)
        {
            _timerSo = timerSo;
        }


        public void CountDown()
        {
            if (!_canCountDown) return;
            _timer -= Time.deltaTime;
        }

        public void StartTimer()
        {
            _canCountDown = true;
        }

        public void ResetTimer()
        {
            _canCountDown = false;
            _timer = _maxTime;
        }

        protected void SetTimer()
        {
            _timer = _maxTime;
        }
    }
}