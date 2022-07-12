using System.Collections;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class ProjectileThrower : MonoBehaviour
    {
        [SerializeField] private GameObject arrowPrefab;
        [SerializeField] private Transform arrowPos;
        [SerializeField] private Animator animator;
        [SerializeField] private string shootTrigger = "shoot";
        
        [SerializeField] private float shootDelay = 1f;
        [SerializeField] private float shootCooldown = 5f;
        
        private bool projectileReadyState = true;
        
        private bool isAttacking;

        private void Update()
        {
            if (!isAttacking || !projectileReadyState)
                return;
            
            StartCoroutine(Shoot());
        }
        
        private IEnumerator Shoot()
        {
            projectileReadyState = false;
            animator.SetTrigger(shootTrigger);
            yield return new WaitForSeconds(shootDelay);
            var position = arrowPos.position;
            var arrow = Instantiate(arrowPrefab, position, arrowPos.rotation);
            yield return new WaitForSeconds(shootCooldown);
            projectileReadyState = true;
        }
        
        public void SetAttackingState(bool attacking) => isAttacking = attacking;
        private void OnDestroy() => StopAllCoroutines();
    }
}
