using UnityEngine;
using System.Collections.Generic;
using AloneTower.SpawnSystem;

public class AIManager : MonoBehaviour
{
    private static AIManager _instance;
    public static AIManager Instance
    {
        get
        {
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    public Transform Target;

    public float RadiusAroundTarget = 2.8f;
    public List<AIUnit> Units = new List<AIUnit>();

    public Queue<Vector3> _aiTargetPositions;


    private void Awake()
    {
        _aiTargetPositions = new Queue<Vector3>();

        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
    }

    public void CalculatePosition(int totalEnemyCount)
    {
        Debug.Log($"Start calculate path");
        for (int i = 0; i < totalEnemyCount; i++)
        {
            _aiTargetPositions.Enqueue(new Vector3(
                Target.position.x + RadiusAroundTarget * Mathf.Cos(2 * Mathf.PI * i / totalEnemyCount),
                Target.position.y,
                Target.position.z + RadiusAroundTarget * Mathf.Sin(2 * Mathf.PI * i / totalEnemyCount)
                ));
        }
        Debug.Log($"End calculate path");
    }
}