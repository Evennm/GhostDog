using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float gravity = -13f;
    [SerializeField] [Range(0.0f, 0.5f)] private float moveSmoothTime = 0.3f;
        

    private float _velocityY = 0.0f;
    private Vector2 _moveDirection;
    private Vector2 _currentDirection = Vector2.zero;
    private Vector2 _currentDirectionVelocity = Vector2.zero;
        
    private CharacterController _controller = null;
        
    private void Start() => _controller = GetComponent<CharacterController>();

    private void OnMove(InputValue value) => _moveDirection = value.Get<Vector2>();

    private void Update()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        _currentDirection = Vector2.SmoothDamp(_currentDirection, _moveDirection,
            ref _currentDirectionVelocity, moveSmoothTime);
            
        if (_controller.isGrounded)
        {
            _velocityY = 0f;
        }

        _velocityY += gravity * Time.deltaTime;
            
        var velocity = (transform.forward * _currentDirection.y + transform.right * _currentDirection.x) * moveSpeed + Vector3.up * _velocityY;
        _controller.Move(velocity * Time.deltaTime);
    }
}