using UnityEngine;

namespace TrafficLightAssesment.ScriptableObjects
{
    [CreateAssetMenu(menuName = "MyAssestment/Attributes/Light Timer", fileName = "TrafficLight Timer So")]
    public class TrafficLightTimerSo : ScriptableObject
    {
        [SerializeField] float _greenTime; 
        [SerializeField] float _yellowTime;
        [SerializeField] float _redTime;

        public float GreenTime => _greenTime;
        public float YellowTime => _yellowTime;
        public float RedTime => _redTime;
    }
    
}
