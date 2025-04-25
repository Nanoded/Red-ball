using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    [SerializeField] private float _force;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Rigidbody2D rigidbody2D))
        {
            rigidbody2D.AddForce(Vector2.right * _force, ForceMode2D.Impulse);
        }
    }
}
