using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject[] wall = new GameObject[6];
        float[] xx = new float[6] { 0, 9, 9, 0, -9, -9 };
        float[] zz = new float[6] { 10.392f, 5.196f, -5.196f, -10.392f, -5.196f, 5.196f };

        for (int i=0; i<6; i++)
        {
            GameObject curwall = GameObject.Find("SW" + i);
            curwall.transform.position = new Vector3(0.0f+xx[i]/2, 4.0f, 0.0f+zz[i]/2);
            if (i % 3 == 1) curwall.transform.RotateAround(curwall.transform.position, Vector3.up, 60.0f);
            else if (i % 3 == 2) curwall.transform.RotateAround(curwall.transform.position, Vector3.up, -60.0f);
        }
	}
	
	// Update is called once per frame
	void Update () {
	}
}
