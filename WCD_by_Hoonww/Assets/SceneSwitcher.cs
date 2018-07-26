using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

    GameManager gm;
	// Use this for initialization
	void Start ()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void Switcher()
    {
        switch (gm.state)
        {
            case 3: SceneManager.LoadScene("InGame"); break;
            case 6: SceneManager.LoadScene("Result"); break;
        }
    }
}
