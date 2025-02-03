using AloneTower;
using AloneTower.Towers;
using UnityEngine;
using UnityEngine.AI;

public class AIUnit : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    private Tower _tower;

    [SerializeField] private EnemyAttack _enemyAttack;

    private bool _isArrived;
    private bool _runState;
    private bool _attackState;

    private void Start()
    {
        _tower = GameObject.FindObjectOfType<Tower>();
        AIManager.Instance.Units.Add(this);
        _runState = true;
    }
    public void MoveTo(Vector3 Position)
    {

        if (_runState)
        {
            _agent.SetDestination(Position);

            if (_agent.pathPending)
            {
                Debug.Log($"Pending");
                return;
            }

            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                _isArrived = true;
                _enemyAttack.Attack();

                _runState = false;
                _attackState = true;
            }
        }
        else if(_attackState)
        {
            _agent.enabled = false;
            transform.parent.LookAt(_tower.transform);
        }
    }
}
