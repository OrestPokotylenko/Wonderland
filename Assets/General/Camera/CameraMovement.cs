using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothTime;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        Vector3 targetPosition = player.position;
        targetPosition.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}