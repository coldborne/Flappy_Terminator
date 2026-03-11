using DefaultNamespace;
using UnityEngine;

namespace Spawn.Spawners
{
    public class EnemySpawner : Spawner<Enemy>
    {
        [SerializeField] private EnemyDestroyer _enemyDestroyer;

        protected override void Initialize(Enemy enemy)
        {
            base.Initialize(enemy);

            int enemySpeed = 5;
            Vector3 enemyDirection = new Vector3(0, 180f, 0);
            float enemyBeforeDeathDelay = 2f;

            enemy.Initialize(enemySpeed, enemyDirection, enemyBeforeDeathDelay);
            
            _enemyDestroyer.Attach(enemy);
        }
    }
}