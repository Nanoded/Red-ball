using Player;
using UnityEngine;

public class ExplosionZone : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;
    [SerializeField] private Transform _explosionPoint;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMovement _))
        {
            Explode();
            enabled = false;
        }
    }

    private void Explode()
    {
        Collider2D[] colliders  = Physics2D.OverlapCircleAll(_explosionPoint.position, _explosionRadius);
        foreach (var colliderInRadius in colliders)
        {
            if (colliderInRadius.TryGetComponent(out Rigidbody2D rigidbodyInRadius))
            {
                Vector2 direction = rigidbodyInRadius.transform.position - _explosionPoint.position;
                float distance = direction.magnitude;
                float forceMultiplier = 1f - (distance / _explosionRadius);
                rigidbodyInRadius.AddForce(direction.normalized * _explosionForce * forceMultiplier, ForceMode2D.Impulse);
            }
        }
    }
}
