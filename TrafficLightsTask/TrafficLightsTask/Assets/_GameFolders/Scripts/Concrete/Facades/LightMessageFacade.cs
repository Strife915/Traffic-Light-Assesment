using MyAssessment.Misc;
using TrafficLightAssesment.Abstract.StateMachine;
using TrafficLightAssesment.Controllers;
using TrafficLightAssesment.Facade;
using TrafficLightAssesment.ScriptableObjects;
using TrafficLightAssesment.Struct;
using UnityEngine;

namespace trafficlightassessment.Facade
{
    public class LightMessageFacade : MonoBehaviour
    {
        [SerializeField] TrafficLightFinder _trafficLightFinder;
        [SerializeField] UiMessageController _uiMessageController;
        [SerializeField] LightMessageHolderSo _lightMessageHolderSo;
        void OnEnable()
        {
            BaseLightFacadeState.OnLightChange += UpdateMessage;
        }

        void UpdateMessage()
        {
            TrafficLightController trafficLightController = _trafficLightFinder.FindTrafficLightWithPlayer();
            if (trafficLightController == null)
            {
                _uiMessageController.ShowNoPlayerMessage();
            }
            else
            {
                LightStateStruct lightStateStruct = trafficLightController.LightStateStruct;
                if (lightStateStruct.IsGreen)
                {
                    _uiMessageController.SetMessage(_lightMessageHolderSo.GreenLightMessage);
                }
                else if (lightStateStruct.IsAmber && LightFacadeHelper.TurnToRed)
                {
                    _uiMessageController.SetMessage(_lightMessageHolderSo.RedAmberMessage);
                }
                else if(lightStateStruct.IsAmber && !LightFacadeHelper.TurnToRed)
                {
                    _uiMessageController.SetMessage(_lightMessageHolderSo.AmberLightMessage);
                }
                else if (lightStateStruct.IsRed)
                {
                    _uiMessageController.SetMessage(_lightMessageHolderSo.RedLightMessage);
                }
            }
        }

        void OnDisable()
        {
            BaseLightFacadeState.OnLightChange -= UpdateMessage;
        }
    }
}

