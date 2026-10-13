
using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;

    [Header("Player Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private Rigidbody2D _rigidbody;
    
    private bool _facingRight = true;

    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
        jumpAction.action.performed += OnJump;
    }

    private void OnDisable()
    {
        jumpAction.action.performed -= OnJump;
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }
    
    private void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _rigidbody.linearVelocity = Vector2.up * jumpForce;
        }
    }

    private void FixedUpdate()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        _rigidbody.linearVelocityX = moveInput.x * speed;
        
        if (!_facingRight && moveInput.x > 0)
            Flip();
        else if (_facingRight && moveInput.x < 0)
            Flip();
    }
    
    private void Flip()
    {
        _facingRight = !_facingRight;

        var scale = transform.localScale;
        scale.x *= -1;

        transform.localScale = scale;
    }
}
