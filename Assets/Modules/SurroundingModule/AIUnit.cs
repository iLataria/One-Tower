using AloneTower.Towers;
using UnityEngine;
using UnityEngine.AI;

public class AIUnit : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Tower _tower;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _tower = GameObject.FindObjectOfType<Tower>();
        AIManager.Instance.Units.Add(this);
    }

    public void MoveTo(Vector3 Position)
    {
        _agent.SetDestination(Position);
    }

    private void OnDestroy()
    {
        _tower.Enemies.Remove(gameObject);
    }
}
