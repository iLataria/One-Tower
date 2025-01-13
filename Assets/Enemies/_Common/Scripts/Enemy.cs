using AloneTower;
using AloneTower.Towers;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private AIUnit _aiUnit;
    [SerializeField] private Transform _fireTarget;
    [SerializeField] private EnemyAttack _enemyAttack;

    private Tower _tower;

    public AIUnit GetAIUnit() => _aiUnit;
    public Transform GetFireTarget() => _fireTarget;
    public EnemyAttack GetEnemyAttack() => _enemyAttack;
    public void SetTower(Tower tower) => _tower = tower;

    private void OnDestroy()
    {
        _tower.Enemies.Remove(this);
    }
}
