using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Transform _firePoint;

    public void Launch(Vector3 direction, int damage)
    {
        Projectile projectile = Instantiate(_projectilePrefab, _firePoint.position, Quaternion.identity);
        projectile.Initialize(direction, damage);

        projectile.gameObject.SetActive(true);
    }
}