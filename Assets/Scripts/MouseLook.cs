using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
        
    private float _cameraPitch = 0.0f;
            
    [SerializeField] private Transform playerCamera = null;
    [SerializeField] private float mouseSensitivity = 3.5f;
    [SerializeField] [Range(0.0f, 0.5f)] private float mouseSmoothTime = 0.03f;
    [SerializeField] private bool lockCursor = true;

    private Vector2 _lookVector;
    private Vector2 _currentMouseDelta = Vector2.zero;
    private Vector2 _currentMouseDeltaVelocity = Vector2.zero;
    private void Start()
    {
        if (!lockCursor) return;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnLook(InputValue value) => _lookVector = value.Get<Vector2>();
    
    private void Update()
    {
        if (Time.timeScale < 1f)
            return;
        
        UpdateMouseLook();
    }

    private void UpdateMouseLook()
    {
        _currentMouseDelta = Vector2.SmoothDamp(_currentMouseDelta, _lookVector, ref _currentMouseDeltaVelocity,
            mouseSmoothTime);
            
        _cameraPitch -= _currentMouseDelta.y * mouseSensitivity;

        _cameraPitch = Mathf.Clamp(_cameraPitch, min:-90, max:90);

        playerCamera.localEulerAngles = Vector3.right * _cameraPitch;

        transform.Rotate(eulers: Vector3.up * _currentMouseDelta.x * mouseSensitivity);
    }
}