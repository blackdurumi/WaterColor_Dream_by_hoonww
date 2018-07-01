using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    MapParser parser;

	// Use this for initialization
	void Start () {
        parser.Parse();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
