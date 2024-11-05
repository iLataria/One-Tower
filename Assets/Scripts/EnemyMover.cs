using UnityEngine;

namespace AloneTower
{
    public class EnemyMover : MonoBehaviour

    {
        [SerializeField]
        private GameObject tower;

        [SerializeField]
        private float speed= 0.3f;

        private void Update()
        {
          transform.LookAt(tower.transform.position);
      
            transform.position = Vector3.Lerp(transform.position,
                        tower.transform.position, speed*Time.deltaTime);
        }
    
    }

}
