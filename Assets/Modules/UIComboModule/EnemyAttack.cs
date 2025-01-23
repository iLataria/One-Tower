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
        private void OnTriggerEnter()
        {
            Debug.Log("Touched");
            _animator.SetTrigger("ReadyToAttack");
            if (!IsCoroutineStarted)
            {
               coroutine= StartCoroutine(DamageRating()); 
                
            }
        }

        private void OnTriggerExit()
        {
            Debug.Log("Exit");

            if (IsCoroutineStarted)
            {
                Debug.Log("Started");
                StopCoroutine(coroutine);
                IsCoroutineStarted = false;
            }
        }

        private IEnumerator DamageRating() 
        {
            
            IsCoroutineStarted = true;

            while (healthSlider.value>=0)
            {
                yield return new WaitForSeconds(damageRate);
                healthSlider.value -= enemyDamage;    
            }
            
            IsCoroutineStarted=false;
            
        }
        
    }

}
