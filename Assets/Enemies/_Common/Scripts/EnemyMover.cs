using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AloneTower.Enemy
{

    public class EnemyMover : MonoBehaviour

    {
        [SerializeField]
        public GameObject tower;
        
        [SerializeField]
        private float speed = 0.3f;

        private NavMeshAgent _agent;

        // Start is called before the first frame update

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            _agent.SetDestination(tower.transform.position);
            //transform.LookAt(tower.transform.position + Vector3.up);

            //transform.position = Vector3.Lerp(transform.position,
            //            tower.transform.position + Vector3.up, speed * Time.deltaTime);
        }

    }

}
