using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AIUnit : MonoBehaviour
{
    public NavMeshAgent Agent;

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        AIManager.Instance.Units.Add(this);
    }

    public void MoveTo(Vector3 Position)
    {
        Agent.SetDestination(Position);
    }
}
