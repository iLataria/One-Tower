using AloneTower.SpawnSystem;
using AloneTower.Towers;
using UnityEngine;

public class TowerIdleState : BaseState
{
    private Tower _tower;
    private SpawnerModule spawnerModule;

    public TowerIdleState(Tower tower)
    {
        _tower = tower;
    }

    public override void Entry()
    {
        base.Entry();
        spawnerModule = GameObject.FindAnyObjectByType<SpawnerModule>();
        spawnerModule.OnSpawnBegin += GetOnSpawnBeginHandler;
    }

    private void GetOnSpawnBeginHandler()
    {
        Debug.Log($"Test");
        _tower.SetState(new TowerFindTargetState(_tower));
    }

    public override void Exit()
    {
        base.Exit();
        spawnerModule.OnSpawnBegin -= GetOnSpawnBeginHandler;
    }

    public override void Update()
    {
        base.Update();
    }
}
