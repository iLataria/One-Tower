using AloneTower;
using AloneTower.Towers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttackState : BaseState
{
    private Slider _healthSlider;
    private AIUnit _aiUnit;
    private Enemy _enemy;
    private EnemyAttack _enemyAttack;

    public EnemyAttackState(Enemy enemy)
    {
        _enemy = enemy;
        _aiUnit = _enemy.GetAIUnit();
        _enemyAttack = _enemy.GetEnemyAttack();
        _healthSlider = GameObject.FindGameObjectWithTag("health_slider").GetComponent<Slider>(); //tmp
    }

    public override void Entry()
    {
        base.Entry();
        _aiUnit.transform.parent.LookAt(_enemy.GetTower().transform);
        _enemy.Animator.SetTrigger("ReadyToAttack");
    }

    public override void Update()
    {
        base.Update();

        if (_healthSlider.value <= 0)
        {
            _enemy.SetState(new EnemyIdleState(_enemy));
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

}
