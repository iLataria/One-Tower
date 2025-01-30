using AloneTower;
using AloneTower.Towers;
using UnityEngine;
using UnityEngine.AI;

public class AIUnit : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    private Tower _tower;

    [SerializeField] private EnemyAttack _enemyAttack;

    private void Start()
    {
        _tower = GameObject.FindObjectOfType<Tower>();
        AIManager.Instance.Units.Add(this);
    }
    public void MoveTo(Vector3 Position)
    {

        _agent.SetDestination(Position);
        if (Vector3.Distance(_agent.transform.position, Position) <= _agent.stoppingDistance)
        {
            _enemyAttack.Attack();
        }

    }
}
