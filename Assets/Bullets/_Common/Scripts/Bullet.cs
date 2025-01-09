using AloneTower.Modules;
using UnityEngine;

namespace AloneTower.Bullets
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rb;

        public Rigidbody RigidBody => _rb;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"Triggered with {other.name}");
            if (other.tag == $"Enemy")
            {
                Debug.Log($"Enemy hit");
                ComboModule comboModule = FindObjectOfType<ComboModule>();
                comboModule.ComboValue += 0.1f;

                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}

