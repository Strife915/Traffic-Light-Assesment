using UnityEngine;

namespace TrafficLightAssesment.ScriptableObjects
{
    [CreateAssetMenu(menuName = "MyAssessment/Attributes/Lighr Messages", fileName = "Light Message Holder")]
    public class LightMessageHolderSo : ScriptableObject
    {
        [SerializeField] string _greenLightMessage;
        [SerializeField] string _amberLightMessage;
        [SerializeField] string _redAmberMessage;
        [SerializeField] string _redLightMessage;

        public string GreenLightMessage => _greenLightMessage;
        public string AmberLightMessage => _amberLightMessage;
        public string RedAmberMessage => _redAmberMessage;
        public string RedLightMessage => _redLightMessage;
    }
}

