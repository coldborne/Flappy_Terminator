using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _firePoint;

    public void Launch(Vector2 direction)
    {
        Projectile projectile = Instantiate(_projectilePrefab, _firePoint.position, Quaternion.identity);
        projectile.Initialize(direction);

        projectile.gameObject.SetActive(true);
    }
}