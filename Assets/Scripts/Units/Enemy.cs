using System;
using System.Collections;
using Interfaces;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(OffscreenDetector))]
public class Enemy : MonoBehaviour, IDamagable
{
    private int _speed;
    private float _beforeDeathDelay;

    private WaitForSeconds _waitForSeconds;
    private Health _health;
    private OffscreenDetector _detector;

    public event Action<Enemy> Died;

    private void Awake()
    {
        _health = new Health();
        _detector = GetComponent<OffscreenDetector>();
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
    }

    public void Initialize(int speed, Vector3 direction, float beforeDeathDelay)
    {
        _speed = speed;
        transform.Rotate(direction, Space.Self);
        _beforeDeathDelay = beforeDeathDelay;

        _waitForSeconds = new WaitForSeconds(_beforeDeathDelay);
    }

    public bool TryGetDamage(int damage)
    {
        return _health.TryGetDamage(damage);
    }

    private void StartDisappear()
    {
        StartCoroutine(DisappearAfterDelay());
    }

    private IEnumerator DisappearAfterDelay()
    {
        yield return _waitForSeconds;

        Died?.Invoke(this);
    }

    private void Die()
    {
        Died?.Invoke(this);
    }
}