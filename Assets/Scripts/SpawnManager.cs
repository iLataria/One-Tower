using UnityEngine;

namespace AloneTower.SpawnSystem
{
    public class Spawner : MonoBehaviour
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

                Instantiate(enemiesPrefab[randEnemyIndex],
                    spawnPoints[randomPointIndex].transform.position, Quaternion.identity);

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

