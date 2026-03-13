using System.Collections;
using Interfaces;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float _speed = 12f;
    [SerializeField, Min(0.1f)] private float _lifeTime = 6f;

    [SerializeField] private ParticleSystem _effect;

    private Rigidbody2D _rigidbody;
    private int _damage;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _rigidbody.gravityScale = 0f;
        _rigidbody.freezeRotation = true;

        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
    }

    private void OnEnable()
    {
        StartCoroutine(Live());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamagable damagable))
        {
            damagable.TryGetDamage(_damage);
            Explode();
        }
    }

    public void Initialize(Vector3 direction, int damage)
    {
        _rigidbody.velocity = direction * _speed;

        transform.right = direction;

        _damage = damage;
    }

    private void Explode()
    {
        Instantiate(_effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private IEnumerator Live()
    {
        double time = 0.0f;

        while (time < _lifeTime)
        {
            time += Time.deltaTime;
            yield return null;
        }
    }
}