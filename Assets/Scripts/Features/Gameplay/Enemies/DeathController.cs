using UnityEngine;
using UnityEngine.Events;

namespace Features.Gameplay.Enemies
{
    public class DeathController : MonoBehaviour
    {
        [SerializeField] private ParticleSystem deathParticles;
        [SerializeField] private Animator animator;
        [SerializeField] private string dieTrigger = "die";
        [SerializeField] private UnityEvent deathEvent;

        public void Die()
        {
            animator.SetTrigger(dieTrigger);
            deathParticles.Play();
            StopAllCoroutines();
            deathEvent?.Invoke();
            enabled = false;
        }
    }
}