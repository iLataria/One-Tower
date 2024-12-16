using AloneTower.Towers;
using UnityEngine;

namespace AloneTower.SpawnSystem
{
    public class SpawnerModule : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] enemiesPrefab;

        [SerializeField]
        private Transform[] spawnPoints;

        private float currentSpawnTimer;
        [SerializeField]
        private float startSpawnDelay;

        [SerializeField]
        private int totalEnemyCount;

        [SerializeField]
        private int totalSpawnedEnemies;

        [SerializeField] private Tower _enemyTarget;

        private int randEnemyIndex;
        private int randomPointIndex;

        private void Start()
        {
            currentSpawnTimer = startSpawnDelay;
        }

        private void Update()
        {
            bool canSpawn = CanSpawn();

            if (!canSpawn)
                return;

            SpawnTimer();
        }

        private void SpawnTimer()
        {  
            if (currentSpawnTimer <= 0)
            {
                randEnemyIndex = Random.Range(0, enemiesPrefab.Length);
                randomPointIndex = Random.Range(0, spawnPoints.Length);

                GameObject enemyMover = Instantiate(enemiesPrefab[randEnemyIndex],
                    spawnPoints[randomPointIndex].transform.position, Quaternion.identity);

                enemyMover.GetComponent<EnemyMover>().tower = _enemyTarget.gameObject;

                currentSpawnTimer = startSpawnDelay;
                totalSpawnedEnemies++;
            }
            else
            {
                currentSpawnTimer -= Time.deltaTime;
            }
        }

        private bool CanSpawn()
        {
            return totalSpawnedEnemies < totalEnemyCount;
        }
    }
}

