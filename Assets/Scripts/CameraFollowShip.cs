using UnityEngine;

public class CameraFollowShip : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new(-71f,63f,-106f);
    [SerializeField] private float damping = 0.5f;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        Vector3 movePosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position,movePosition,ref velocity, damping);
    }
}
