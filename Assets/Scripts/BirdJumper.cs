using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdJumper : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputReader.JumpKeyPressed += Jump;
    }

    private void OnDisable()
    {
        _inputReader.JumpKeyPressed -= Jump;
    }

    private void Jump()
    {
        Vector2 velocity = _rigidbody.velocity;
        velocity.y = _jumpForce;
        _rigidbody.velocity = velocity;
    }
}
