using UnityEngine;
using Zenject;

namespace Features.Gameplay.AttackAreas
{
    public class LookAtAttackArea : MonoBehaviour
    {
        [Inject] private AttackAreaNavigator attackAreaNavigator;

        private void Update()
        {
            if(!attackAreaNavigator.GetLastAttackArea(out var lastAttackArea))
                return;
            
            transform.LookAt(lastAttackArea.position, Vector3.up);
        }
    }
}