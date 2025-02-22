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

        public int GetTotalEnemyCount()
        {
            return totalEnemyCount;
        }

        private void Start()
        {
            AIManager.Instance.CalculatePosition(totalEnemyCount);
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
                    spawnPoints[randomPointIndex].transform.position, Quaternion.LookRotation(-transform.forward,Vector3.up));


                Enemy enemy = enemyGO.GetComponent<Enemy>();
                enemy.SetTower(_tower);
                enemy.SetState(AIUnit.EnemyState.RunState);
                
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

