using Player;
using UnityEngine;

namespace Level
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.OnDeath.Invoke();
            }
        }
    }
}
