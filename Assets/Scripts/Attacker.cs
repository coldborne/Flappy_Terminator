using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damage;
    [SerializeField] private ProjectileLauncher _projectileLauncher;

    private SpriteRenderer _spriteRenderer;

    public void Shoot()
    {
        Vector2 direction = GetDirection();
        _projectileLauncher.Launch(direction);
    }

    private Vector2 GetDirection()
    {
        Vector2 direction = transform.right;

        Debug.Log(direction);

        if (_spriteRenderer.flipX)
        {
            direction = -direction;
        }

        return direction;
    }
}
