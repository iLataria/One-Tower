using AloneTower.SpawnSystem;
using UnityEngine;
using UnityEngine.UI;

namespace AloneTower
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField]
        private float enemyDamage= 1f;

        // made reference only with public;
        public Slider healthSlider;

        private void OnTriggerStay()
        {
           healthSlider.value-= enemyDamage*Time.deltaTime;
          
        }

        
    }

}
