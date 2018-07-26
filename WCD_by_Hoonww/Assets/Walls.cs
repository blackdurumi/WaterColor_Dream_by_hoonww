using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] wall = new GameObject[6];

        for(int i=0; i<6; i++)
        {
            //wall[i] = GameObject.FindGameObjectsWithTag("wall")[i].GetComponent<SpriteRenderer>().sprite = Resources.Load("walls/Start" + i.ToString());
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
