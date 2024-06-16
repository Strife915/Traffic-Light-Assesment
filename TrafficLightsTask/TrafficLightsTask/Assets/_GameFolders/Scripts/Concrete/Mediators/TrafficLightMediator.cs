using System.Collections.Generic;
using TrafficLightAssesment.Abstract.Mediator;
using TrafficLightAssesment.Controllers;
using TrafficLightAssesment.Struct;
using UnityEngine;

namespace TrafficLightAssesment.Mediator
{
    //Due to zenject restriction, I made this class to be a MonoBehaviour, ServiceLocator might implement for this situation.
    public class TrafficLightMediator : MonoBehaviour, IMediator<TrafficLightController>
    {
        List<TrafficLightController> _trafficLights = new List<TrafficLightController>();

        public void Notify(TrafficLightController sender)
        {
            LightStateStruct senderState = sender.LightStateStruct;
            foreach (var trafficLight in _trafficLights)
            {
                if (trafficLight != sender)
                {
                    switch (senderState)
                    {
                        case var state when state.IsGreen:
                            SetTrafficLightState(trafficLight, isRed: true);
                            break;
                        case var state when state.IsAmber:
                            SetTrafficLightState(trafficLight, isAmber: true);
                            break;
                        case var state when state.IsRed:
                            SetTrafficLightState(trafficLight, isGreen: true);
                            break;
                    }
                }
            }
        }

        void SetTrafficLightState(TrafficLightController trafficLight, bool isGreen = false,
            bool isAmber = false, bool isRed = false)
        {
            trafficLight.LightStateStruct.IsGreen = isGreen;
            trafficLight.LightStateStruct.IsAmber = isAmber;
            trafficLight.LightStateStruct.IsRed = isRed;
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