using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        private readonly UnityEvent _onDeath = new UnityEvent();
    
        public UnityEvent OnDeath => _onDeath;

        private void OnDestroy()
        {
            _onDeath.RemoveAllListeners();
        }
    }
}
