using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform[] targets = new Transform[2];

    private Rigidbody2D _rigidbody;
    private int _currentTarget;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, targets[_currentTarget].position) < 0.1f)
        {
            _currentTarget = (_currentTarget + 1) % targets.Length;
            Flip();
        }

        transform.position = Vector2.MoveTowards(transform.position, targets[_currentTarget].position, speed * Time.deltaTime);
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit by enemy!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
