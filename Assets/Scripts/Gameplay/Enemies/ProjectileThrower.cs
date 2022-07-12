using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class ProjectileThrower : MonoBehaviour
    {
        [SerializeField] private GameObject throwablePrefab;
        [SerializeField] private Transform throwablePos;
        [SerializeField] private Animator animator;
        [SerializeField] [CanBeNull] private ParticleSystem shootParticles;
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
            var position = throwablePos.position;
            var arrow = Instantiate(throwablePrefab, position, throwablePos.rotation);
            if (shootParticles != null)
                shootParticles.Play();
            yield return new WaitForSeconds(shootCooldown);
            projectileReadyState = true;
        }

        public void SetAttackingState(bool attacking) => isAttacking = attacking;
        private void OnDestroy() => StopAllCoroutines();
    }
}