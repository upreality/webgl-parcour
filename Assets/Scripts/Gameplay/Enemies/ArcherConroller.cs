using System.Collections;
using Gameplay.AttackAreas;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Gameplay.Enemies
{
    public class ArcherConroller : MonoBehaviour
    {
        [Inject] private AttackAreaNavigator attackAreaNavigator;

        [SerializeField] Transform root;
        [SerializeField] private GameObject arrowPrefab;
        [SerializeField] private Transform arrowPos;
        [SerializeField] private ParticleSystem deathParticles;
        [SerializeField] private Animator animator;
        [SerializeField] private string shootTrigger = "shoot";
        [SerializeField] private string dieTrigger = "die";
        [SerializeField] private float shootDelay = 1f;
        [SerializeField] private float shootCooldown = 5f;
        [SerializeField] private int attackDistance;
        [SerializeField] private UnityEvent deathEvent;
        private Transform player;
        private Transform targetArea;

        private bool isAttacking = false;
        private bool arrowReady = true;

        private void Start() => player = GameObject.FindWithTag("Player").transform;

        private void Update()
        {
            var look = player.position - root.position;
            isAttacking = look.magnitude < attackDistance;
            if (!isAttacking || !arrowReady)
                return;

            if (!attackAreaNavigator.GetLastAttackArea(out var area))
                return;

            var distance = area.position - root.position;
            if (distance.magnitude > attackDistance)
                return;

            targetArea = area;
            StartCoroutine(Shoot());
        }

        public void Die()
        {
            animator.SetTrigger(dieTrigger);
            deathParticles.Play();
            StopAllCoroutines();
            deathEvent?.Invoke();
            enabled = false;
        }

        private IEnumerator Shoot()
        {
            arrowReady = false;
            animator.SetTrigger(shootTrigger);
            yield return new WaitForSeconds(shootDelay);
            var position = arrowPos.position;
            var arrow = Instantiate(arrowPrefab, position, arrowPos.rotation);
            arrow.transform.LookAt(targetArea.position);
            yield return new WaitForSeconds(shootCooldown);
            arrowReady = true;
        }

        private void OnDestroy() => StopAllCoroutines();
    }
}