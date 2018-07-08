using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour {

    public static Transform[] _waypoints;

    void Awake()
    {
        _waypoints = new Transform[transform.childCount];

        for(int i = 0;i<_waypoints.Length;i++)
        {
            _waypoints[i] = transform.GetChild(i);
        }

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
