using UnityEngine;
using Zenject;

namespace Features.Fall
{
    public class FallDetector : MonoBehaviour
    {
        [SerializeField] private float fallHeight;
        [SerializeField] private Transform target;

        [Inject] private IFallNavigator fallNavigator;

        private bool fallen = false;

        private void Update()
        {
            if (target.position.y <= fallHeight == fallen)
                return;

            fallen = !fallen;
            if (fallen)
                fallNavigator.StartFall();
        }
    }
}