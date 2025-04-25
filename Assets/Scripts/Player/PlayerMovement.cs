using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private const string GroundLayer = "Ground";

        [SerializeField] private float _groundCheckDistance;
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private int _ballVelocityX;

        private void FixedUpdate()
        {
            if (_ballVelocityX != 0)
            {
                _rigidbody2D.velocity = new Vector2(_ballVelocityX * _speed, _rigidbody2D.velocity.y);
            }
        }
    
        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(transform.position - Vector3.up * _groundCheckDistance,
                transform.lossyScale.y, LayerMask.GetMask(GroundLayer));
        }

        //direction = -1 left, 0 stop, 1 right
        public void Move(int direction) => _ballVelocityX = direction;
    
        public void Jump()
        {
            if(IsGrounded()) _rigidbody2D.velocity += Vector2.up * _jumpForce;
        }
        
        public void StopMovement()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.angularVelocity = 0;
            transform.rotation = Quaternion.identity;
        }
    }
}
