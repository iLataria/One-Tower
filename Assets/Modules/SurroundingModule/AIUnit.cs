using AloneTower;
using AloneTower.SpawnSystem;
using AloneTower.Towers;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class AIUnit : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    
    public NavMeshAgent Agent=> _agent;
    private Tower _tower;

    [SerializeField] private EnemyAttack _enemyAttack;
    public float RadiusAroundTarget = 1f;
    
    public Vector3 _agentTargetPos;
    private SpawnerModule _spawnerModule;

    private void Start()
    {
        _spawnerModule = FindAnyObjectByType<SpawnerModule>();
        _tower = GameObject.FindObjectOfType<Tower>();
    }

   

  
    
  
   
}
