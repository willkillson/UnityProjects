using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    [Header("               Attributes")]
    public GameObject standardTurretPrefab;
    [Header("               SetUp")]
    [Header("               CalculatedAtRuntime")]

    //PRIVATE
    private GameObject turretToBuild;

    //This is called right before start!
    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("BuildManager is being created twice!!!!");
            return;
        }

        instance = this;//singleton patern 
        //this is to prevent multiple BuildManagers from exsiting
    }

	// Use this for initialization
	void Start () {
        turretToBuild = standardTurretPrefab;//this is where we are going to introduce more options
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //FUNCTIONS
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
