using UnityEngine;

[RequireComponent(typeof(ProjectileLauncher))]
public class Attacker : MonoBehaviour
{
    [SerializeField, Min(1)] private int _damage;
    private ProjectileLauncher _projectileLauncher;

    private void Awake()
    {
        _projectileLauncher = GetComponent<ProjectileLauncher>();
    }

    public void Shoot()
    {
        Vector2 direction = GetDirection();
        _projectileLauncher.Launch(direction, _damage);
    }

    private Vector2 GetDirection()
    {
        Vector2 direction = transform.right;
        float rotationAngle = 180f;

        if (Mathf.Approximately(Mathf.Abs(transform.rotation.y), rotationAngle))
        {
            direction = -direction;
        }

        return direction.normalized;
    }
}