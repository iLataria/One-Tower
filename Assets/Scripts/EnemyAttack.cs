using AloneTower.SpawnSystem;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace AloneTower
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField]
        private float enemyDamage= 1f;

        [SerializeField]
        private float damageRate=3f;

        // made reference only with public;
        public Slider healthSlider;

        private void OnTriggerEnter()
        {
          StartCoroutine(DamageRating());
          Debug.Log(damageRate);
        }

        private IEnumerator DamageRating() 
        {
            while (true)
            {
                yield return new WaitForSeconds(damageRate);
                healthSlider.value -= enemyDamage;
            }
            
        }
        
    }

}
