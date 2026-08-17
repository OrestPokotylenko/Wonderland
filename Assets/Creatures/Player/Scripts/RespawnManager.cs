using System.Collections;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _respawnDelay = 5f;

    private CameraMovement _cameraMovement;

    private void Awake()
    {
        _cameraMovement = Camera.main.GetComponent<CameraMovement>();
    }

    public void Respawn()
    {
        StartCoroutine(RespawnPlayer());
    }

    private IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(_respawnDelay);

        if (_playerPrefab == null)
        {
            yield break;
        }

        if (_spawnPoint == null)
        {
            yield break;
        }

        GameObject player = Instantiate(
            _playerPrefab,
            _spawnPoint.position,
            Quaternion.identity
        );

        _cameraMovement.SetTarget(player.transform);
    }
}