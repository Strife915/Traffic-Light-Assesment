using MyAssessment.Misc;
using TMPro;
using TrafficLightAssesment.Facade;
using TrafficLightAssesment.Struct;
using UnityEngine;
using UnityEngine.UI;

namespace TrafficLightAssesment.Controllers
{
    public class DriveButtonController : MonoBehaviour
    {
        [SerializeField] Button _button;
        [SerializeField] TextMeshProUGUI _messageText;
        [SerializeField] TrafficLightFinder _trafficLightFinder;
        void Awake()
        {
            _button.onClick.AddListener(UpdateButtonText);
        }

        void UpdateButtonText()
        {
            TrafficLightController trafficLightController = _trafficLightFinder.FindTrafficLightWithPlayer();
            if(_trafficLightFinder == null) return;
            LightStateStruct lightStateStruct = trafficLightController.LightStateStruct;
            if (lightStateStruct.IsGreen)
            {
                _messageText.text = "Drive";
            }
            else if (lightStateStruct.IsAmber && LightFacadeHelper.TurnToRed)
            {
                _messageText.text = "Cant Drive";
            }
            else if(lightStateStruct.IsAmber && !LightFacadeHelper.TurnToRed)
            {
                _messageText.text = "Drive";
            }
            else if (lightStateStruct.IsRed)
            {
                _messageText.text = "Cant Drive";
            }
        }
    }
}

