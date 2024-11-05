using AloneTower.SpawnSystem;
using UnityEngine;
using UnityEngine.UI;

namespace AloneTower
{
    public class EnemyAttack : MonoBehaviour
    {

        [SerializeField]
        private float enemyDamage= 1f;

        [SerializeField]
        private Slider healthSlider;

        private void OnTriggerStay()
        {
           
           healthSlider.value -= enemyDamage*Time.deltaTime;
        }

        //public void GetHealthSlider(Slider health)
        //{
        //    healthSlider= health;
        //}
    }

}
