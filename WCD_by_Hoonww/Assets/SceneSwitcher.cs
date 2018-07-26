using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

    public void Switcher(int x)
    {
        switch (x)
        {
            case 3: SceneManager.LoadScene("InGame"); break;
            case 6: SceneManager.LoadScene("Result"); break;
        }
    }
}
