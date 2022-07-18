using System.Collections;
using ExternalAssets.Mini_First_Person_Controller.Scripts;
using UnityEngine;

namespace Features.Gameplay.Enemies
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Transform root;
        [SerializeField] private float punchForce = 10f;
        [SerializeField] private float arrowSpeed = 10f;
        [SerializeField] private float lifetime = 3f;
        [SerializeField] private float affectDuration = 1f;

        private void Start() => StartCoroutine(Lifetime());

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player") || !other.TryGetComponent<FirstPersonMovement>(out var movement))
            {
                Destroy(gameObject);
                return;
            }

            var forward = root.forward;
            var vector = new Vector3(forward.x, 1f, forward.z);
            Debug.Log(vector.ToString());
            movement.StartAffect(affectDuration,vector * punchForce);
            Destroy(gameObject);
        }

        private IEnumerator Lifetime()
        {
            var timer = lifetime;
            while (timer > 0f)
            {
                root.localPosition += root.forward * Time.deltaTime * arrowSpeed;
                timer -= Time.deltaTime;
                yield return null;
            }

            Destroy(gameObject);
        }

        private void OnDestroy() => StopAllCoroutines();
    }
}