using AloneTower.Towers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState: BaseState
{
    private Enemy _enemy;
    public EnemyIdleState(Enemy enemy)
    {
        _enemy = enemy;
    }
    public override void Entry()
    {
        base.Entry();
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