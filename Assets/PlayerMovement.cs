using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;


public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    [SerializeField] List<Transform> _wayMoveList = new List<Transform>();
    [SerializeField] int _wayPoint = 0;
    [SerializeField] Transform _target, _gun;
    [SerializeField] GameObject _bullet;
    bool _isFire = false;
    Rigidbody _rigi;
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _rigi = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        EnemyDetect();
        
    }
    void PlayerMove()
    {
        _navMeshAgent.destination = _wayMoveList[_wayPoint].position;
        if (Vector3.Distance(this.transform.position, _wayMoveList[_wayPoint].transform.position) < 0.2f)
        {
            LookAtTarget();
        }
    }



    void LookAtTarget()
    {
        Vector3 lookPos = _target.transform.position - this.transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 2);
        float rot = Mathf.Atan2(lookPos.z, lookPos.x) * Mathf.Rad2Deg;
        _isFire=true;



        if (_isEnemy)
        {
            _wayPoint++;
            if (_wayPoint >= _wayMoveList.Count)
            {
                _wayPoint = 0;
            }
        }

    }

    [SerializeField] int _length = 100;
    [SerializeField] bool _isEnemy = false;
    private GameObject _hitObj;
    private Ray _forwardRay;
    void EnemyDetect()
    {
        _hitObj = null;
        var Ray = new Ray(this.transform.position , this.transform.forward);
        Debug.DrawRay(this.transform.position, this.transform.forward * _length, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(Ray, out hit, _length))
        {
            _hitObj = hit.transform.gameObject;
            Debug.Log("hitobj" + hit.transform.gameObject.name);
            Debug.Log("hitobj" + hit.transform.gameObject.tag);

        }
        if (_hitObj == null)
        {
            Debug.Log("_hitobj null");
            _isEnemy = false;
            return;
        }

        if (_hitObj.transform.gameObject.CompareTag("Boss"))
        {
            Debug.Log("_isEnemytrue");
            _isEnemy = true;
        }
        else
        {
            Debug.Log("_isEnemyfalse");
            _isEnemy = false;
        }

    }



    void Checkfire()
    {
        if (_isFire)
        {
            Instantiate(_bullet, _gun.transform.position, _gun.transform.rotation);
        }
        _isFire = false;
    }

}
