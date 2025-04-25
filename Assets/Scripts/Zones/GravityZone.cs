using UnityEngine;

namespace Zones
{
    public class GravityZone : MonoBehaviour
    {
        [SerializeField] private float _force;
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out Rigidbody2D rigidbody2D))
            {
                rigidbody2D.AddForce(Vector2.up * _force, ForceMode2D.Force);
            }
        }
    }
}
