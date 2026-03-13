using System;
using Interfaces;
using UnityEngine;

[RequireComponent(typeof(BirdJumper))]
[RequireComponent(typeof(CollisionHandler))]
[RequireComponent(typeof(Attacker))]
public class Player : MonoBehaviour, IDamagable
{
    [SerializeField] private InputReader _inputReader;

    private Health _health;
    private CollisionHandler _collisionHandler;
    private Attacker _attacker;

    public event Action CollidedWithObstacle;
    public event Action Died;

    private void Awake()
    {
        _health = new Health();
        _collisionHandler = GetComponent<CollisionHandler>();
        _attacker = GetComponent<Attacker>();
    }

    private void OnEnable()
    {
        _health.Died += Die;
        _collisionHandler.CollisionHandled += ProcessCollision;
        _inputReader.ShootKeyPressed += Shoot;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
        _collisionHandler.CollisionHandled -= ProcessCollision;
        _inputReader.ShootKeyPressed -= Shoot;
    }

    private void Die()
    {
        Died?.Invoke();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        CollidedWithObstacle?.Invoke();
    }

    private void Shoot()
    {
        _attacker.Shoot();
    }

    public bool TryGetDamage(int damage)
    {
        return _health.TryGetDamage(damage);
    }
}