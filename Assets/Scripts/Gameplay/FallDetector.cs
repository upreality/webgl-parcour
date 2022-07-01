using Doozy.Engine;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    [SerializeField] private float fallHeight;
    [SerializeField] private Transform target;

    [SerializeField] private string startFallGameEvent = "Fall";

    private bool fallen = false;

    void Update()
    {
        if (target.position.y <= fallHeight == fallen)
            return;

        fallen = !fallen;
        if (fallen)
            GameEventMessage.SendEvent(startFallGameEvent);
    }
}