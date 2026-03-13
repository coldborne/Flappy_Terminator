using System;
using System.Collections;
using Interfaces;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(OffscreenDetector))]
public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField, Min(1)] private int _attackDelay;
    
    private int _speed;
    private float _beforeDeathDelay;

    private WaitForSeconds _waitForSecondsAttackDelay;
    private WaitForSeconds _waitForSecondsDisappearDelay;

    private Health _health;
    private OffscreenDetector _detector;
    private Attacker _attacker;

    private bool _isShooting;

    public event Action<Enemy> Died;

    private void Awake()
    {
        _health = new Health();
        _detector = GetComponent<OffscreenDetector>();
        _attacker = GetComponent<Attacker>();
        
        _waitForSecondsAttackDelay = new WaitForSeconds(_attackDelay);
    }

    private void Update()
    {
        transform.Translate(transform.right * (Time.deltaTime * _speed), Space.World);
    }

    private void OnEnable()
    {
        _health.Died += Die;
        _detector.WentOffscreen += StartDisappear;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
        _detector.WentOffscreen -= StartDisappear;

        StopCoroutine(Shooting());
    }

    public void Initialize(int speed, Vector3 direction, float beforeDeathDelay)
    {
        _speed = speed;
        transform.Rotate(direction, Space.Self);
        _beforeDeathDelay = beforeDeathDelay;
        
        _waitForSecondsDisappearDelay = new WaitForSeconds(_beforeDeathDelay);
        
        _isShooting = true;
        StartCoroutine(Shooting());
    }

    public bool TryGetDamage(int damage)
    {
        return _health.TryGetDamage(damage);
    }

    private IEnumerator Shooting()
    {
        while (_isShooting)
        {
            _attacker.Shoot();
            yield return _waitForSecondsAttackDelay;
        }
    }

    private void StartDisappear()
    {
        StartCoroutine(DisappearAfterDelay());
    }

    private IEnumerator DisappearAfterDelay()
    {
        yield return _waitForSecondsDisappearDelay;

        Died?.Invoke(this);
    }

    private void Die()
    {
        Died?.Invoke(this);
    }
}