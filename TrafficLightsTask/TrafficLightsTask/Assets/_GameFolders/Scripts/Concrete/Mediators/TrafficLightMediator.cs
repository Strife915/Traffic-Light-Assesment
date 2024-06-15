using System.Collections.Generic;
using TrafficLightAssesment.Abstract.Mediator;
using TrafficLightAssesment.Controllers;
using UnityEngine;

namespace TrafficLightAssesment.Mediator
{
    //Due to zenject restriction, I made this class to be a MonoBehaviour, ServiceLocator might implement for this situation.
    public class TrafficLightMediator : MonoBehaviour, IMediator<TrafficLightController>
    {
        List<TrafficLightController> _trafficLights = new List<TrafficLightController>();

        public void Notify(TrafficLightController sender)
        {
            foreach (var trafficLight in _trafficLights)
            {
                if (trafficLight != sender)
                {
                    trafficLight.SetLightToRed();
                }
            }
        }

        public void Register(TrafficLightController participant)
        {
            if (!_trafficLights.Contains(participant))
            {
                _trafficLights.Add(participant);
            }
        }
    }
}