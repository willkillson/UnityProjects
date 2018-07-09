﻿using UnityEngine;
using UnityEngine.Networking;




public class PlayerController : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    



    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    [Command]
    void CmdFire()
    {
        //Create the bullet from the bullet prefab
        var bullet = (GameObject)Instantiate(bulletPrefab,bulletSpawn);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;


        // Spawn the bullet on the Clients
        NetworkServer.Spawn(bullet);

        Destroy(bullet, 2.0f);
    }

    public override void OnStartLocalPlayer()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }
}