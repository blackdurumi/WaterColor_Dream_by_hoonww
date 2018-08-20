using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

    public void Switcher(int x)
    {
        switch (x)
        {
            case 2: SceneManager.LoadScene("StageSelect"); break;
            case 4: SceneManager.LoadScene("InGame"); break;
            case 7: SceneManager.LoadScene("Result"); break;
        }
    }
}
