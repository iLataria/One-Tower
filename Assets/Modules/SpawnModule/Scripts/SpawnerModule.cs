using UnityEngine;
using AloneTower.Enemies;
using AloneTower.Towers;

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

        private Tower _tower;

        private int randEnemyIndex;
        private int randomPointIndex;

        private void Start()
        {
            _tower = FindObjectOfType<Tower>();
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

                GameObject enemyGO = Instantiate(enemiesPrefab[randEnemyIndex],
                    spawnPoints[randomPointIndex].transform.position, Quaternion.identity);


                Enemy enemy = enemyGO.GetComponent<Enemy>();
                enemy.SetTower(_tower);

                AIManager.Instance.Units.Add(enemy.GetAIUnit());
                _tower.Enemies.Add(enemy);

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

