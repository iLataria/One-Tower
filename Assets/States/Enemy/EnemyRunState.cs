using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static AIUnit;

public class EnemyRunState : BaseState
{   
    private AIUnit _aiUnit;
    private Enemy _enemy;
    private Slider _towerHealthSlider;

    public EnemyRunState( Enemy enemy)
    {
        _enemy = enemy;
        _aiUnit = _enemy.GetAIUnit(); 
    }

    public override void Entry()
    {
        base.Entry();
        Vector3 targetPos = AIManager.Instance._aiTargetPositions.Dequeue();
        _aiUnit.Agent.SetDestination(targetPos);

        _towerHealthSlider = GameObject.FindGameObjectWithTag("health_slider").GetComponent<Slider>(); //tmp
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

         // получить жизни башни из скрипта башни
        if(_towerHealthSlider.value <= 0)
        {
            _enemy.SetState(new EnemyIdleState(_enemy));
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
        _aiUnit.Agent.enabled = false;
    }
}
