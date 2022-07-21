using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace FPSController
{
    public class FirstPersonMovement : MonoBehaviour
    {
        [Inject] private IMovementInputProvider inputProvider;
        [SerializeField] private GroundCheck check;
        [SerializeField] [CanBeNull] private UnityEvent onAffected;

        public float speed = 5;
        public float speedMultiplier = 1;

        [Header("Running")] public bool canRun = true;
        public bool IsRunning { get; private set; }
        public float runSpeed = 9;

        private bool affected = false;

        Rigidbody m_rigidbody;

        /// <summary> Functions to override movement speed. Will use the last added override. </summary>
        public List<Func<float>> speedOverrides = new();

        private void Awake()
        {
            // Get the rigidbody on this.
            m_rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (affected)
                return;

            // Update IsRunning from input.
            if (check.isGrounded)
            {
                IsRunning = canRun && inputProvider.GetRunningInput();
            }

            // Get targetMovingSpeed.
            float targetMovingSpeed = IsRunning ? runSpeed : speed;
            targetMovingSpeed *= speedMultiplier;
            if (speedOverrides.Count > 0)
            {
                targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
            }

            // Get targetVelocity from input.
            var input = inputProvider.GetInput();
            Vector2 targetVelocity = input * targetMovingSpeed;
            // Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

            // Apply movement.
            m_rigidbody.velocity =
                transform.rotation * new Vector3(targetVelocity.x, m_rigidbody.velocity.y, targetVelocity.y);

            AvoidStacking();
        }

        private void AvoidStacking()
        {
            // Get the velocity
            var horizontalMove = m_rigidbody.velocity;
            // Don't use the vertical velocity
            horizontalMove.y = 0;
            // Calculate the approximate distance that will be traversed
            var distance = horizontalMove.magnitude * Time.fixedDeltaTime;
            // Normalize horizontalMove since it should be used to indicate direction
            horizontalMove.Normalize();

            // Check if the body's current velocity will result in a collision
            if (check.isGrounded) return;
            var hits = m_rigidbody.SweepTestAll(horizontalMove, distance).Where(hit => !hit.collider.isTrigger);
            if (hits.ToList().Count == 0) return;

            // If so, fix the movement
            m_rigidbody.velocity = new Vector3(0, m_rigidbody.velocity.y, 0);
        }

        public void ResetVelocity()
        {
            if (m_rigidbody == null)
                return;

            m_rigidbody.velocity = Vector3.zero;
            m_rigidbody.angularVelocity = Vector3.zero;
        }

        public void SetSpeedMul(float mul) => speedMultiplier = mul;

        public void StartAffect(float duration, Vector3 force) => StartCoroutine(StartAffectCoroutine(duration, force));

        private IEnumerator StartAffectCoroutine(float duration, Vector3 force)
        {
            affected = true;
            try
            {
                onAffected?.Invoke();
            }
            catch (Exception e)
            {
            }

            m_rigidbody.AddForce(force);
            yield return new WaitForSeconds(duration);
            affected = false;
        }

        private void OnDestroy() => StopAllCoroutines();

        public interface IMovementInputProvider
        {
            public Vector2 GetInput();
            public bool GetRunningInput();
        }
    }
}