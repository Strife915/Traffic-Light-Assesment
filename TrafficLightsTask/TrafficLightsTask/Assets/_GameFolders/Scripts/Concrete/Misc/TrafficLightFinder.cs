using TrafficLightAssesment.Controllers;
using UnityEngine;

namespace MyAssessment.Misc
{
    public class TrafficLightFinder : MonoBehaviour
    {
        [SerializeField] TrafficLightController[] _trafficlights;

        public TrafficLightController FindTrafficLightWithPlayer()
        {
            foreach (TrafficLightController trafficLightController in _trafficlights)
            {
                if (trafficLightController.IsPlayerHere)
                {
                    return trafficLightController;
                }
            }
            return null;
        }
    }

}
