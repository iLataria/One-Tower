using AloneTower.Bullets;
using AloneTower.Modules;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AloneTower.Towers
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private SoundController _soundController;
        [SerializeField] private Transform _towerHead;
        [SerializeField] private Transform _towerBarrel;
        [SerializeField] private Transform _target;
        [SerializeField] private float _fireSpeed;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _aimRotationSpeed;
        [SerializeField] private float _attackRadius;
        [SerializeField] private ParticleSystem _VFXExplosionTower;
        [SerializeField] public Slider healthSlider;
        [SerializeField] private ParticleSystem _deadEffect;
        [SerializeField] private GameObject _restartButton;
        

        private float _fireTimer;
        private float _fireInterval;
        private Quaternion _initialRotation;
        private Transform _targetInPreviousFrame;

        public bool IsSlowMotion { get; set; }

        public List<Enemy> Enemies { get; set; }

        private void Awake()
        {
            Enemies = new List<Enemy>();
            _restartButton.SetActive(false);
        }

        private void Update()
        {
            //if (IsSlowMotion)
            //    return;

            if (healthSlider.value <= 0)
            {
                DeadTower();
            }
            Debug.DrawRay(_firePoint.position, _firePoint.transform.forward * 100f, Color.green);
            _target = GetClosestTarget(_attackRadius);

            if (!_target)
                return;

            bool isTargetInRadius = IsClosestTargetInTowerAttackRadius(_target);

            if (!isTargetInRadius)
                return;

            if (_targetInPreviousFrame != null && _targetInPreviousFrame != _target)
                _initialRotation = _towerHead.transform.rotation;
            
            bool isTowerHeadAimed;
            AimHead(_target, out isTowerHeadAimed);

            bool isBarrelAimed = false;
            if (isTowerHeadAimed)
                AimBarrel(_target, out isBarrelAimed);

            if (isBarrelAimed)
            {
                bool isTimeToFire = CanFire();
                if (isTimeToFire)
                    Fire();
            }

            _targetInPreviousFrame = _target;
        }

        private Transform GetClosestTarget(float attackRadius)
        {
            Transform closestAliveEnemy = null;
            float closestDistanceToAliveEnemy = Mathf.Infinity;

            foreach (var enemy in Enemies)
            {
                float towerEnemyDistance = Vector3.Distance(enemy.transform.position, transform.position);
                
                if (towerEnemyDistance > closestDistanceToAliveEnemy)
                    continue;

                closestDistanceToAliveEnemy = towerEnemyDistance;
                closestAliveEnemy = enemy.GetFireTarget();
            }

            return closestAliveEnemy;
        }

        private bool IsClosestTargetInTowerAttackRadius(Transform _target)
        {
            return Vector3.Distance(transform.position, _target.position) < _attackRadius;
        }

        private bool CanFire()
        {
            _fireInterval = 1f / _fireSpeed;
            _fireTimer += Time.deltaTime;

            if (_fireTimer > _fireInterval)
            {
                _fireTimer = 0;
                return true;
            }

            return false;
        }

        private void Fire()
        {
            Debug.Log($"Fire");
            _VFXExplosionTower.Play();
            _soundController.PlaySound();
            Ray ray = new Ray(_firePoint.position, _firePoint.transform.forward);
            
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    Debug.Log("Hit");
                    ComboModule comboModule = FindObjectOfType<ComboModule>();
                    float currentComboValue = comboModule.GetComboValue();
                    currentComboValue += 0.1f;
                    comboModule.SetComboValue(currentComboValue);
                    Enemy enemy=hit.collider.gameObject.GetComponentInParent<Enemy>();
                    StartCoroutine(DestroyEnemy(enemy));                  
                }
            }
        }

        private void AimHead(Transform aimTransform, out bool isTowerHeadAimed)
        {
            Vector3 dir = (_target.position - _towerHead.position).normalized;
            dir.y = 0f;
            _towerHead.transform.rotation = Quaternion.RotateTowards(_towerHead.transform.rotation, Quaternion.LookRotation(dir, Vector3.up), _aimRotationSpeed * Time.deltaTime);
            isTowerHeadAimed = _towerHead.transform.rotation == Quaternion.LookRotation(dir, Vector3.up);
        }

        private void AimBarrel(Transform aimTransform, out bool isBarrelAimed)
        {
            Vector3 dir = (_target.position - _towerBarrel.position).normalized;
            _towerBarrel.transform.rotation = Quaternion.RotateTowards(_towerBarrel.transform.rotation, Quaternion.LookRotation(dir, Vector3.up), _aimRotationSpeed * Time.deltaTime);
            isBarrelAimed = _towerBarrel.transform.rotation == Quaternion.LookRotation(dir, Vector3.up);
        }

        private void DeadTower()
        {
            _deadEffect.Play();
            _restartButton.SetActive(true);

        }

        private IEnumerator DestroyEnemy(Enemy enemy)
        {
            Debug.Log($"{enemy.gameObject.GetInstanceID()}");
            enemy.GetParticleSystem().Play();
            Destroy(enemy.GetVisuals());
            enemy.GetCollider().enabled = false;
            _target = null;
            Enemies.Remove(enemy);
            yield return new WaitForSeconds(0.4f);
            Destroy(enemy.gameObject);
            yield return null;
        }

     

    }
}
