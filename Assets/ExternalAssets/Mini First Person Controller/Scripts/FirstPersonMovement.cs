using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class FirstPersonMovement : MonoBehaviour
{
    [Inject] private IMovementInputProvider inputProvider;
    [SerializeField] private GroundCheck check;

    public float speed = 5;
    public float speedMultiplier = 1;

    [Header("Running")] public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;

    Rigidbody m_rigidbody;

    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<Func<float>> speedOverrides = new();

    void Awake()
    {
        // Get the rigidbody on this.
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
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
        var distance =  horizontalMove.magnitude * Time.fixedDeltaTime;
        // Normalize horizontalMove since it should be used to indicate direction
        horizontalMove.Normalize();

        // Check if the body's current velocity will result in a collision
        if(check.isGrounded) return;
        var hits = m_rigidbody.SweepTestAll(horizontalMove, distance).Where(hit => !hit.collider.isTrigger);
        if (hits.ToList().Count == 0) return;
        
        // If so, fix the movement
        m_rigidbody.velocity = new Vector3(0, m_rigidbody.velocity.y, 0);
    }

    public void ResetVelocity()
    {
        m_rigidbody.velocity = Vector3.zero;
        m_rigidbody.angularVelocity = Vector3.zero;
    }

    public void SetSpeedMul(float mul) => speedMultiplier = mul;

    public interface IMovementInputProvider
    {
        public Vector2 GetInput();
        public bool GetRunningInput();
    }
}