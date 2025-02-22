using AloneTower;
using AloneTower.SpawnSystem;
using AloneTower.Towers;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class AIUnit : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    private Tower _tower;

    [SerializeField] private EnemyAttack _enemyAttack;
    public float RadiusAroundTarget = 1f;
    private EnemyState _currentState =EnemyState.IdleState;
    public Vector3 _agentTargetPos;
    private SpawnerModule _spawnerModule;

    private void Start()
    {
        _spawnerModule = FindAnyObjectByType<SpawnerModule>();
        _tower = GameObject.FindObjectOfType<Tower>();
    }

    private void Update()
    {
        switch (_currentState)
        {
            case EnemyState.RunState:
                RunStateUpdate();
                break;
            case EnemyState.AttackState:
                AttackStateUpdate();
                break;
            case EnemyState.IdleState:
                IdleStateUpdate();
                break;
            case EnemyState.DeadState:
                DeadStateUpdate();
                break;
            default:
                break;
        }
    }

    public void AttackStateEnter()
    {
        Debug.Log($"Attack state enter");
        _agent.enabled = false;
        transform.parent.LookAt(_tower.transform);
    }
    public void AttackStateUpdate()
    {
        Debug.Log($"Attack state update");
        _enemyAttack.Attack();
    }
    public void AttackStateExit()
    {
        Debug.Log($"Attack state exit");
    }
    public void IdleStateEnter()
    {
        Debug.Log("Idle state enter");
    }
    public void IdleStateUpdate()
    {
        Debug.Log("Idle state update");
    }
    public void IdleStateExit()
    {
        Debug.Log("Idle state exit");
    }
    public void RunStateEnter()
    {
        Vector3 targetPos = AIManager.Instance._aiTargetPositions.Dequeue();
        Debug.Log($"Run state enter");
        _agent.SetDestination(targetPos);
    }
    public void RunStateUpdate()
    {
        Debug.Log($"Run state update");

        if (_agent.pathPending)
        {
            Debug.Log($"Pending");
            return;
        }
        bool isArrived = _agent.remainingDistance <= .1f;
        if (isArrived)
        {
            SetState(EnemyState.AttackState);
            return;
        }
    }
    public void RunStateExit()
    {
        Debug.Log($"Run state exit");
    }
    public void DeadStateEnter()
    {
        Debug.Log("Dead state enter");
    }
    public void DeadStateUpdate()
    {
        Debug.Log("Dead state update");
    }
    public void DeadStateExit()
    {
        Debug.Log("Dead state exit");
    }
    public void SetState(EnemyState targetState)
    {
        if (_currentState == targetState)
        {
            Debug.Log($"Already in the state");
            return;
        }

        switch (_currentState)
        {
            case EnemyState.RunState:
                RunStateExit();
                break;
            case EnemyState.AttackState:
                AttackStateExit();
                break;
            case EnemyState.IdleState:
                IdleStateExit();
                break;
            case EnemyState.DeadState:
                DeadStateExit();
                break;
            default:
                break;
        }

        _currentState = targetState;

        switch (_currentState)
        {
            case EnemyState.RunState:
                RunStateEnter();
                break;
            case EnemyState.AttackState:
                AttackStateEnter();
                break;
            case EnemyState.IdleState:
                IdleStateEnter();
                break;
            case EnemyState.DeadState:
                DeadStateEnter(); 
                break;
            default:
                break;
        }
    }

    public enum EnemyState
    {
        IdleState,
        RunState,
        AttackState,
        DeadState
    }
}
