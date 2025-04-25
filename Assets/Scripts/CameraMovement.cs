using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _leftBorder = -10f;
    [SerializeField] private float _rightBorder = 10f;
    private Transform _target;

    private void LateUpdate()
    {
        if (_target == null) return;
        Vector3 newPosition = transform.position;
        newPosition.x = Mathf.Clamp(_target.position.x, _leftBorder, _rightBorder);
        transform.position = newPosition;
    }
    
    public void SetTarget(Transform target) => _target = target;
}
