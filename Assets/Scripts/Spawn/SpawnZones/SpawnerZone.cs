using System.Collections;
using Spawn.Spawners;
using UnityEngine;

namespace Spawn.SpawnZones
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class SpawnerZone<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T _prefab;
        [SerializeField] private Spawner<T> _spawner;

        [Header("Настройки")]
        [SerializeField, Range(1, 50)]
        private float _cooldown;

        private WaitForSeconds _waitForSeconds;
        private bool _isActive;

        private BoxCollider2D _collider;

        private void Awake()
        {
            _waitForSeconds = new WaitForSeconds(_cooldown);
            _isActive = true;

            _collider = GetComponent<BoxCollider2D>();
            _collider.isTrigger = true;
            
            StartCoroutine(SpawnNext());
        }

        private IEnumerator SpawnNext()
        {
            Bounds zoneBounds = _collider.bounds;

            float x = zoneBounds.center.x;

            while (_isActive)
            {
                float minY = zoneBounds.min.y;
                float maxY = zoneBounds.max.y;
                float y = Random.Range(minY, maxY);

                Vector2 enemyPosition = new Vector2(x, y);

                _spawner.Spawn(_prefab, enemyPosition, transform);
                yield return _waitForSeconds;
            }
        }
    }
}