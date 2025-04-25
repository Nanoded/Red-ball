using Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Checkpoint[] _checkpoints;
        [SerializeField] private CameraMovement _cameraMovement;
        [SerializeField] private PlayerMovement _playerPrefab;
        [SerializeField] private MovementUIController _movementUIController;
        private Transform _respawnPoint;
        private PlayerMovement _playerMovement;
    
        private void Start()
        {
            SpawnAndInitPlayer();
            SubscribeToController();
            InitCheckpoints();
            _cameraMovement.SetTarget(_playerMovement.transform);
            _respawnPoint = _playerSpawnPoint;
        }

        private void SubscribeToController()
        {
            _movementUIController.SubscribeToJumpTrigger(EventTriggerType.PointerDown, _playerMovement.Jump);
        
            _movementUIController.SubscribeToLeftTrigger(EventTriggerType.PointerDown, _playerMovement.Move);
            _movementUIController.SubscribeToLeftTrigger(EventTriggerType.PointerUp, _playerMovement.Move);
        
            _movementUIController.SubscribeToRightTrigger(EventTriggerType.PointerDown, _playerMovement.Move);
            _movementUIController.SubscribeToRightTrigger(EventTriggerType.PointerUp, _playerMovement.Move);
        }

        private void SpawnAndInitPlayer()
        {
            _playerMovement = Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);
            if (_playerMovement.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.OnDeath.AddListener(RespawnPlayer);
                playerHealth.OnDeath.AddListener(_playerMovement.StopMovement);
            }
        }

        private void InitCheckpoints()
        {
            foreach (var checkpoint in _checkpoints)
            {
                checkpoint.OnOpen.AddListener(OpenCheckpoint);
            }
        }
    
        private void RespawnPlayer() => _playerMovement.transform.position = _respawnPoint.position;

        private void OpenCheckpoint(Transform checkpoint) => _respawnPoint = checkpoint;
    }
}
