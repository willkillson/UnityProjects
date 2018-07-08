using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [Header("               Attributes")]

    public float _bulletSpeeed = 70.0f;
    public float _bulletDamage = 5.0f;

    public GameObject impactEffect;
    private Transform _target;
	
	// Update is called once per frame

	void Update ()
    {


        if (_target == null)
        {
            //if the target is NULL then we aren't targeting anything, so destroy this item and return
            Destroy(gameObject);
            return;

        }

        Vector3 direction = _target.position - transform.position;
        float distanceThisFrame = _bulletSpeeed * Time.deltaTime;


        if(direction.magnitude<= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);










	}

    public void SetTarget(Transform target)
    {
        _target = target;
    }
    private void HitTarget()
    {
        ApplyDamageToTarget();
        GameObject effectins = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectins, 2.0f);
       // Destroy(_target.gameObject);
        Destroy(gameObject);//destroy the bullet
        return;
    }
    private void ApplyDamageToTarget()
    {
        // GameObject targ = (GameObject)_target;
        EnemyMovement em = _target.GetComponent<EnemyMovement>();
        em.ApplyDamage(_bulletDamage);
        //me.isEAlive
        //     Bullet bullet = bulletGO.GetComponent<Bullet>();
    }

}
