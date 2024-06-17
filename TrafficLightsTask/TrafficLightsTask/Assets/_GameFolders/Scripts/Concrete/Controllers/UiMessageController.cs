using TMPro;
using UnityEngine;

namespace TrafficLightAssesment.Controllers
{
    public class UiMessageController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _messageText;
        
        public void SetMessage(string message)
        {
            _messageText.text = message;
        }

        public void ShowNoPlayerMessage()
        {
            _messageText.text = "Player is not on the traffic light.";
        }
        
    }
}

