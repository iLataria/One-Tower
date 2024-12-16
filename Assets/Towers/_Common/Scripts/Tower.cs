using AloneTower.Bullets;
using UnityEngine;



namespace AloneTower.Towers
{
    public class Tower : MonoBehaviour
    {
       // [SerializeField] private SoundController _soundController;
        [SerializeField] private Transform _towerHead;
        [SerializeField] private Transform _towerBarrel;
        [SerializeField] private Transform _target;
        [SerializeField] private Bullet _projectile;
        [SerializeField] private float _fireSpeed;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _aimRotationSpeed;

        private float _fireTimer;
        private float _fireInterval;
        private Quaternion _initialRotation;
        private Transform _targetInPreviousFrame;

        private void Update()
        {
            if (!_target)
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
                bool isTargetExistsAndReadyToFire = CanFire();
                if (isTargetExistsAndReadyToFire)
                    Fire(_projectile);
            }

            _targetInPreviousFrame = _target;
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

        private void Fire(Bullet projectile)
        {
            //_soundController.PlaySound();
            Bullet bullet = Instantiate(projectile, _firePoint.position, Quaternion.LookRotation(_towerBarrel.forward, Vector3.up));
            bullet.RigidBody.velocity = _towerBarrel.forward * _bulletSpeed;
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
    }
}
