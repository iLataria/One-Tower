using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AIUnit;

public class EnemyRunState : BaseState
{   
    private AIUnit _aiUnit;
    private Enemy _enemy;
    public EnemyRunState( AIUnit aiUnit,Enemy enemy)
    {
        _enemy = enemy;
        _aiUnit = aiUnit; 
    }

    public override void Entry()
    {
        base.Entry();
        Vector3 targetPos = AIManager.Instance._aiTargetPositions.Dequeue();
        _aiUnit.Agent.SetDestination(targetPos);
    }

    public override void Update()
    {
        base.Update();
        if (_aiUnit.Agent.pathPending)
        {
            Debug.Log($"Pending");
            return;
        }
        bool isArrived = _aiUnit.Agent.remainingDistance <= .1f;
        if (isArrived)
        {
           _enemy.SetState(new EnemyAttackState(_enemy));
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
        _aiUnit.Agent.enabled = false;
    }
}
