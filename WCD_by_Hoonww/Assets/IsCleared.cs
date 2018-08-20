using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class IsCleared : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Resources/GameData/StageResult.txt");
        
        for (int i=1; i<=5; i++)
        {
            string sources = sr.ReadLine();
            if (sources == "1") GameObject.Find("Button " + i.ToString()).GetComponent<Image>().color = new Color(255.0f, 0.0f, 0.0f);
        }
        sr.Close();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
