using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterEnemy : MonoBehaviour {

   private int wave = 0;
    int health = 0;
    private bool isAlive = true;
    public bool isEAlive()
    {
        return isAlive;
    }
    public void HurtEnemy(int amount)
    {
        health -= amount;
    }
	// Use this for initialization
	void Start () {
		switch (wave)
        {
            case 0:
                health = 50;
                break;
            case 1:
                health = 100;
                break;
            case 2:
                health = 150;
                break;
            case 3:
                health = 200;
                break;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(health<=0)
        {
            isAlive = false;
        }
	}
}
