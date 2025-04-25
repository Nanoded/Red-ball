using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Level
{
    public class Checkpoint : MonoBehaviour
    {
        private readonly UnityEvent<Transform> _onOpen = new UnityEvent<Transform>();
    
        public UnityEvent<Transform> OnOpen => _onOpen;
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerMovement _))
            {
                _onOpen.Invoke(transform);
                gameObject.SetActive(false);
            }
        }
    }
}
