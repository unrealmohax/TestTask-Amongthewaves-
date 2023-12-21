using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _mainCamera;

    private void Start()
    {
        GameObject playerGO = CreatePlayer();
        PreparationCamera(playerGO);
    }

    private GameObject CreatePlayer()
    {
        GameObject playerGo = Instantiate(_playerPrefab, _spawnPoint.position, Quaternion.Euler(0, 90, 0));
        Character player = playerGo.GetComponent<Character>();
        
        if (player != null)
        {
            player.SetSpawnPoint(_spawnPoint.position);
        }

        return playerGo;
    }

    private void PreparationCamera(GameObject playerGO)
    {
        CameraFollow cameraFollow = _mainCamera.AddComponent<CameraFollow>();
        
        if (cameraFollow != null)
        {
            cameraFollow.SetTarget(playerGO.transform);
            cameraFollow.SetPositionX(playerGO.transform.position.x);
        }
    }
}
