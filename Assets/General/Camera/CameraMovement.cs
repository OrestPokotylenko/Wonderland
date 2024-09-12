using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float followSpeed;

    private void LateUpdate()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        Vector3 targetPosition = player.position;
        targetPosition.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}