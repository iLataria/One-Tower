using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyPrefab;

    [SerializeField]
    private Transform[] spawnPoints;

  
    private float spawnDelay;
    [SerializeField]
    private float startSpawnDelay;

    [SerializeField]
    private int enemyCount;
    [SerializeField]
    private int nowEnemies;

    private int randEnemy;
    private int randomPoint;

   
    

    // Start is called before the first frame update
    void Start()
    {
       spawnDelay= startSpawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (spawnDelay <= 0 && nowEnemies < enemyCount)
        {
            randEnemy = Random.Range(0, enemyPrefab.Length);
            randomPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefab[randEnemy], 
                spawnPoints[randomPoint].transform.position,Quaternion.identity);

            spawnDelay = startSpawnDelay;
            nowEnemies++;
        }
        else {
        
            spawnDelay -= Time.deltaTime;
        }
    }
}
