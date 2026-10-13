
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionReference moveAction;

    [Header("Player Movement")]
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody;
    
    private bool _facingRight = true;

    public void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }
    
    private void FixedUpdate()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");
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
