using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{



    [Header ("               Attributes")]

    public float _turnSpeed = 10f;
    public float range = 15f;
    public float fireRate = 1f;
    public string enemyTag = "Enemy";



    [Header("               SetUp")]
    public Transform _partToRotate;
    public GameObject _BulletPreFab;
    public Transform _firePoint;

    [Header("               CalculatedAtRuntime")]
    private Transform _target = null;


    private float _fireCountDown = 0;
    // public Transform _position;
    // Use this for initialization

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null)
        {
            return;
        }

        Vector3 direction = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = lookRotation.eulerAngles;

         //Vector3 rotation = Quaternion.Lerp(_partToRotate.rotation,lookRotation,Time.deltaTime* _turnSpeed).eulerAngles;
        _partToRotate.rotation = Quaternion.Euler(0f,rotation.y-90f,0f);



        if (_fireCountDown<=0f)
        {
           // Debug.Log("FireTheTurret!");
            TurretFire();
            _fireCountDown = 1f/fireRate;//This might be the better way to program
            //_fireCountDown = fireRate;
        }
        _fireCountDown -= Time.deltaTime;
        //_fireCountDown -= fireRate * Time.deltaTime;


    }






    void TurretFire()
    {
        if (_target != null)
        {
            GameObject bulletGO = (GameObject)Instantiate(_BulletPreFab, _firePoint.position, _firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.SetTarget(_target);
        }

    }
    void UpdateTarget()
    {
     
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        //Debug.Log(""+enemies.Length);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject Enemy in enemies)
        {
     
            float calculatedistance = Vector3.Distance(transform.position, Enemy.transform.position);
            if (calculatedistance < shortestDistance)
            {
           
                shortestDistance = calculatedistance;
                nearestEnemy = Enemy;

            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
