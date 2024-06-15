using System.Collections.Generic;
using TrafficLightAssesment.Abstract.Mediator;
using TrafficLightAssesment.Controllers;
using UnityEngine;

namespace TrafficLightAssesment.Mediator
{
    public class TrafficLightMediator : IMediator<TrafficLightController>
    {
        List<TrafficLightController> _trafficLights;
        public void Notify(TrafficLightController sender, string eventMessage)
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
                participant.SetMediator(this);
            }
        }
        
    }
    
}
