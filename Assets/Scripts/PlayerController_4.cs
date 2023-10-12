using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController_4 : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private int extraJumps;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Count")] 
    [SerializeField] private Text countText;

    private int _count;
    private Rigidbody2D _rigidbody;

    private bool _facingRight = true;
    private int _extraJumpValue;

    private bool IsGrounded => Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _extraJumpValue = extraJumps;
    }

    private void Update()
    {
        var moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);

        _rigidbody.velocity = new Vector2(moveInput * speed, _rigidbody.velocity.y);

        if (!_facingRight && moveInput > 0)
            Flip();
        else if (_facingRight && moveInput < 0)
            Flip();

        if (IsGrounded)
        {
            _extraJumpValue = extraJumps;
        }

        if (Input.GetButtonDown("Jump") && 
            (IsGrounded || _extraJumpValue-- > 0))
        {
                _rigidbody.velocity = Vector2.up * jumpForce;
        }
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
        if (!other.CompareTag("Coin")) return;

        _count++;
        countText.text = $"Count: {_count}";

        other.gameObject.SetActive(false);
    }
}
