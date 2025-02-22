using AloneTower.SpawnSystem;
using AloneTower.Towers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerStateFindTarget : BaseState
{
    private Tower _tower;
    private Slider _healthSlider;
    private Transform _target;

    private Transform _targetInPreviousFrame;
    private SpawnerModule _spawnerModule;

    public TowerStateFindTarget(Tower tower)
    {
        _healthSlider = GameObject.FindGameObjectWithTag("health_slider").GetComponent<Slider>();
        _tower = tower;
    }

    public override void Entry()
    {
        base.Entry();
        _spawnerModule = GameObject.FindAnyObjectByType<SpawnerModule>();

        _target = GetClosestTarget(_tower.AttackRadius);

        Debug.Log($"Nearest enemy {_target.name}");
        bool isTargetInRadius = IsClosestTargetInTowerAttackRadius(_target);

        if (isTargetInRadius)
        {
            Debug.Log($"Attack");
            Enemy enemy = _target.GetComponent<Enemy>();
            _tower.SetState(new TowerStateAttackTarget(_tower, enemy.GetFireTarget()));
            return;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (_healthSlider.value <= 0)
        {
            _tower.SetState(null);
            return;
        }
    }

    private bool IsClosestTargetInTowerAttackRadius(Transform target)
    {
        return Vector3.Distance(_tower.transform.position, target.position) < _tower.AttackRadius;
    }

    private Transform GetClosestTarget(float attackRadius)
    {
        Transform closestAliveEnemy = null;

        float closestDistanceToAliveEnemy = Mathf.Infinity;

        foreach (var enemy in _spawnerModule.Enemies)
        {
            float towerEnemyDistance = Vector3.Distance(enemy.transform.position, _tower.transform.position);

            if (towerEnemyDistance >= closestDistanceToAliveEnemy)
                continue;

            closestDistanceToAliveEnemy = towerEnemyDistance;

            //closestAliveEnemy = enemy.transform;
            List<Enemy> nearestEnemies = GetNearestTargets(closestDistanceToAliveEnemy);
            closestAliveEnemy = GetClosestTargetByDirection(nearestEnemies);

        }

        return closestAliveEnemy;
    }

    private List<Enemy> GetNearestTargets(float closestDistance)
    {
        List<Enemy> nearestEnemies = new List<Enemy>();

        foreach (var enemy in _spawnerModule.Enemies)
        {
            if (Mathf.Approximately(closestDistance, Vector3.Distance(enemy.transform.position, _tower.transform.position)))
            {
                nearestEnemies.Add(enemy);
            }
        }
        return nearestEnemies;
    }

    private Transform GetClosestTargetByDirection(List<Enemy> nearestEnemies)
    {
        if (nearestEnemies.Count == 0 || nearestEnemies == null)
            return null;

        Transform closestEnemyByDirection = null;
        float smallestAngle = Mathf.Infinity;
        Vector3 towerCurrentDirection = _tower.Barrel.transform.forward;

        foreach (Enemy enemy in nearestEnemies)
        {
            Vector3 DirectionToTarget = enemy.transform.position - _tower.transform.position;
            float angleToTarget = Vector3.Angle(towerCurrentDirection, DirectionToTarget);

            if (Mathf.Abs(angleToTarget) < smallestAngle)
            {
                smallestAngle = angleToTarget;
                closestEnemyByDirection = enemy.transform;
            }
        }
        return closestEnemyByDirection;
    }
}
