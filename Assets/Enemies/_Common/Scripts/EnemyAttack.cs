using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{

    //public Slider healthSlider;

    [SerializeField]
    private float enemyDamage = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerStay()
    {
        //healthSlider.value -= enemyDamage;
    }
}
