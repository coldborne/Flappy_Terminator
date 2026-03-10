using UnityEngine;

namespace Spawn.Spawners
{
    public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
    {
        public void Spawn(T prefab, Vector2 position, Transform parent)
        {
            T enemy = Instantiate(prefab, position, Quaternion.identity, parent);
            Initialize(enemy);
        }

        protected virtual void Initialize(T enemy)
        {
            enemy.gameObject.SetActive(true);
        }
    }
}
