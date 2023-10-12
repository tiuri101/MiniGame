using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController_1 : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody;

    private bool _facingRight = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
    }

    private void Flip()
    {
        _facingRight = !_facingRight;

        var scale = transform.localScale;
        scale.x *= -1;

        transform.localScale = scale;
    }
}
