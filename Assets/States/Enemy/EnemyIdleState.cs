using AloneTower.Towers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState: BaseState
{
    private Enemy _enemy;
    private Animator _animator;
    public EnemyIdleState(Enemy enemy)
    {
        _enemy = enemy;
        _animator = enemy.Animator;
    }

    public override void Entry()
    {
        base.Entry();
        if (_animator != null)
            _animator.SetBool("TowerIsDead", true);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }
}