using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;
    [SerializeField] private int extraJumps;
    
    [Header("Player Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Count")]
    [SerializeField] private Text countText;
    
    private Rigidbody2D _rigidbody;
    
    private bool _facingRight = true;
    private int _remainingJumps;
    
    private int _count;
    
    private bool IsGrounded => Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _remainingJumps = extraJumps;
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
        if (context.performed && (_remainingJumps > 0 || IsGrounded))
        {
            _rigidbody.linearVelocity = Vector2.up * jumpForce;
            if (!IsGrounded)
                _remainingJumps--;
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
        
        if (IsGrounded)
            _remainingJumps = extraJumps;
    }
    
    private void Flip()
    {
        _facingRight = !_facingRight;

        var scale = transform.localScale;
        scale.x *= -1;

        transform.localScale = scale;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (!other.CompareTag("Coin")) return;

        _count++;
        countText.text = $"Count: {_count}";

        other.gameObject.SetActive(false);
    }
}
