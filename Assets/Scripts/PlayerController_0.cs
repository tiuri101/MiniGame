using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController_0 : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);

        _rigidbody.velocity = new Vector2(moveInput * speed, _rigidbody.velocity.y);
    }
}
