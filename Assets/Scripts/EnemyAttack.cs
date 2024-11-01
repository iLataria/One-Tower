
using UnityEngine;

using UnityEngine.UI;

namespace AloneTower
{
    public class EnemyAttack : MonoBehaviour
    {

        

        [SerializeField]
        private float enemyDamage= 1f;

        private Slider healthSlider;
 
        private void Start()
        {
            healthSlider=FindObjectOfType<Slider>();
        }

        private void Update()
        {
        
        }

        private void OnTriggerStay()
        {

           healthSlider.value -= enemyDamage;
        }
    }

}
