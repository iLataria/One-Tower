using AloneTower.Modules;
using AloneTower.SpawnSystem;
using AloneTower.Towers;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerStateAttackTarget : BaseState
{
    private Tower _tower;
    private Transform _target;
    
    private float _fireTimer;
    private float _fireInterval;
    private ParticleSystem _particleSystem;
    private SoundController _soundController;
    private Transform _firePoint;
    private SpawnerModule _spawnerModule;

    public TowerStateAttackTarget(Tower tower, Transform target)
    {
        _tower = tower;
        _target = target;
        _spawnerModule = GameObject.FindAnyObjectByType<SpawnerModule>();
        _particleSystem = GameObject.FindGameObjectWithTag("vfx_explosion_tower").GetComponent<ParticleSystem>();
        _soundController = GameObject.FindGameObjectWithTag("sounds_controller").GetComponent<SoundController>();
        _firePoint = GameObject.FindGameObjectWithTag("tower_fire_point").transform;
    }

    public override void Entry()
    {
        base.Entry();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

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
    }

    private void AimHead(Transform aimTransform, out bool isTowerHeadAimed)
    {
        Vector3 dir = (_target.position - _tower.Head.position).normalized;
        dir.y = 0f;
        _tower.Head.transform.rotation = Quaternion.RotateTowards(_tower.Head.transform.rotation, Quaternion.LookRotation(dir, Vector3.up), _tower.AimRotationSpeed * Time.deltaTime);
        isTowerHeadAimed = _tower.Head.transform.rotation == Quaternion.LookRotation(dir, Vector3.up);
    }

    private void AimBarrel(Transform aimTransform, out bool isBarrelAimed)
    {
        Vector3 dir = (_target.position - _tower.Barrel.position).normalized;
        _tower.Barrel.transform.rotation = Quaternion.RotateTowards(_tower.Barrel.transform.rotation, Quaternion.LookRotation(dir, Vector3.up), _tower.AimRotationSpeed * Time.deltaTime);
        isBarrelAimed = _tower.Barrel.transform.rotation == Quaternion.LookRotation(dir, Vector3.up);
    }

    private bool CanFire()
    {
        _fireInterval = 1f / _tower.FireSpeed;
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
        _particleSystem.Play();
        _soundController.PlaySound();
        Ray ray = new Ray(_firePoint.position, _firePoint.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Enemy")
                Hit(hit);
        }
    }

    private void Hit(RaycastHit hit)
    {
        Debug.Log("Hit");
        Enemy enemy = hit.collider.gameObject.GetComponentInParent<Enemy>();
  
        _spawnerModule.Enemies.Remove(enemy);
        GameObject.Destroy(enemy.gameObject);

        _tower.SetState(new TowerStateFindTarget(_tower));
        //Implement setStateEnemy;
    }

    //private IEnumerator DestroyEnemy(Enemy enemy)
    //{
    //    Debug.Log($"{enemy.gameObject.GetInstanceID()}");
    //    enemy.GetParticleSystem().Play();
    //    Destroy(enemy.GetVisuals());
    //    enemy.GetCollider().enabled = false;
    //    _target = null;
    //    Enemies.Remove(enemy);

    //    yield return new WaitForSeconds(0.4f);
    //    Destroy(enemy.gameObject);
    //    yield return null;
    //}
}
