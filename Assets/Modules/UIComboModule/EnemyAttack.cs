using AloneTower.SpawnSystem;
using AloneTower.Towers;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AloneTower
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField]
        private float enemyDamage = 2f;

        [SerializeField]
        private Animator _animator;

        public Slider healthSlider;

        public void Attack()
        {
            Tower tower = GetComponentInParent<Enemy>().GetTower();
            healthSlider = tower.HealthSlider;
            transform.LookAt(tower.transform);

            if (_animator != null)
                _animator.SetTrigger("ReadyToAttack");

            healthSlider.value -= enemyDamage;
        }
    }
}
