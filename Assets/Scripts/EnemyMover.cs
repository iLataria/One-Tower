using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AloneTower
{

    public class EnemyMover : MonoBehaviour

    {
        [SerializeField]
        public GameObject tower;

        [SerializeField]
        private float speed= 0.3f;


        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
          transform.LookAt(tower.transform.position);
      
            transform.position = Vector3.Lerp(transform.position,
                        tower.transform.position, speed*Time.deltaTime);
        }
    
    }

}
