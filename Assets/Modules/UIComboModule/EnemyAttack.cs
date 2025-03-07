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
        private float enemyDamage= 2f;

        [SerializeField]
        private float damageRate=2f;

        [SerializeField]
        private Animator _animator;

        private Coroutine coroutine;

        public Slider healthSlider;
        
        private bool IsCoroutineStarted=false;

        public void Attack()
        {
            Tower tower = GetComponentInParent<Enemy>().GetTower();
            healthSlider = tower.healthSlider;
            transform.LookAt(tower.transform);
            if(_animator != null)
            _animator.SetTrigger("ReadyToAttack");
            
            if (!IsCoroutineStarted)
            {
               coroutine= StartCoroutine(Damage()); 
                
            }
        }

       
        private IEnumerator Damage() 
        {
            if (!healthSlider)
                yield break;

            IsCoroutineStarted = true;

            while (healthSlider.value>0)
            {
                yield return new WaitForSeconds(damageRate);
                healthSlider.value -= enemyDamage;    
            }
            IsCoroutineStarted=false;
            Enemy enemy = GetComponentInParent<Enemy>();
            enemy.SetState(new EnemyIdleState(enemy));
            
        }
        
    }

}
