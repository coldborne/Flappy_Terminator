using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyDestroyer : MonoBehaviour
    {
        public void Attach(Enemy enemy)
        {
            enemy.Died += DestroyObject;
        }

        private void DestroyObject(Enemy enemy) 
        {
            Destroy(enemy.gameObject);
        }
    }
}