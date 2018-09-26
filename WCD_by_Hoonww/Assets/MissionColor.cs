using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log(GameManager.I.Goal);
        GetComponent<Image>().color = GameManager.I.Goal;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
