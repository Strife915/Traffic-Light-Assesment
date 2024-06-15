using TrafficLightAssesment.Abstract.Mediator;
using TrafficLightAssesment.Controllers;
using UnityEngine;

namespace TrafficLightAssesment.Facades
{
    public class LightFacade : MonoBehaviour
    {
        [SerializeField] TrafficLightController _initialGreen;
        IMediator<TrafficLightController> _mediator;

        void Awake()
        {
            _mediator = GetComponent<IMediator<TrafficLightController>>();
        }

        void Start()
        {
            _initialGreen.SetLightToGreen();
        }
    }
}