using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;


public class Boss : MonoBehaviour
{
    [SerializeField] Text _bossHealth, _bossBullet;
    [SerializeField] Transform _target;
    [SerializeField] Transform _gun;
    [SerializeField] GameObject _bullet;
    public int _health = 5, _ammo = 5;
    public bool _isOutOfAmmo = false, _isDeath = false;
    private void OnEnable()
    {
        _isOutOfAmmo = false;
        _isDeath = false;
    }
    void Update()
    {
        _bossHealth.text = "Boss Health" + _health.ToString();
        _bossBullet.text = "Boss Bullet" + _ammo.ToString();

        _timefireCount -= Time.deltaTime;
        LookAtTarget();
       // BossFire();
        CheckAmmo();
        CheckHealth();
    }
    void LookAtTarget()
    {
        this.transform.LookAt(_target);
    }

    [SerializeField] float _fireSpeed = 1;
    float _timefireCount;
    void BossFire()
    {
        if (_timefireCount > 0)
        {
            return;
        }
        _timefireCount = _fireSpeed;
        Instantiate(_bullet, _gun.transform.position + new Vector3(1f, 0, 0), _gun.transform.rotation);
        _ammo--;
        Debug.Log("BossFire");
    }
    void CheckAmmo()
    {
        if (_ammo <= 0) { _isOutOfAmmo = true; }
    }
    void CheckHealth()
    {
        if (_health <= 0) { _isDeath = true; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            _health--;
        }
    }
}