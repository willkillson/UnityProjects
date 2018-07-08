using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float health = 5.0f;
    public float speed  = 40f;
    private Transform target;
    private int _targetIndex = 0;

    
	// Use this for initialization
	void Start ()
    {
        target = WayPoints._waypoints[0];
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if(health<= 0)
        {
            Destroy(gameObject);
            return;
        }

        if ((Vector3.Distance(transform.position, target.position) <= 0.4f) && (_targetIndex == WayPoints._waypoints.Length))
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            if (Vector3.Distance(transform.position, target.position) <= 0.4f)
            {
                ReTarget();
            }
        }
        
    }


    void ReTarget()
    {
        _targetIndex++;
        if (_targetIndex >= WayPoints._waypoints.Length)
        {
            return;
        }
        target = WayPoints._waypoints[_targetIndex];


    }
}
