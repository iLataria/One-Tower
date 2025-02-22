using AloneTower.SpawnSystem;
using AloneTower.Towers;
using UnityEngine;

public class TowerStatesIdle : BaseState
{
    private Tower _tower;
    private SpawnerModule spawnerModule;

    public TowerStatesIdle(Tower tower)
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
        _tower.SetState(new TowerStateFindTarget(_tower));
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
