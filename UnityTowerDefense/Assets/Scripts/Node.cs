using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    private GameObject occupant= null;

    public Color hoverColor;
    private Color defaultColor;
    private Renderer rend;

    void OnMouseDown()
    {
        if(occupant!=null)
        {
            Debug.Log("Can't build here!");
            return;
        }
        //build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        occupant = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;

    }
    void OnMouseExit()
    {
        rend.material.color = defaultColor;
    }
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
