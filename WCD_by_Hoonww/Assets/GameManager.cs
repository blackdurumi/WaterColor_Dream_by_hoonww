using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public int state = 1;
    public int stage = 0;

    private static GameManager instance;
    public static GameManager I
    {
        get { return instance; }
    }

    void Start()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    public void WhichStage(int n)
    {
        GameManager.I.stage = n;
    }

    public void ChangeState(string name)
    {
        //stage = 0;
        Debug.Log(GameManager.I);
        Debug.Log(GameManager.I.state);
        switch (name)
        {
            case "StartButtonPressed": GameManager.I.state = 2; break;
            case "StageSelected": GameManager.I.state = 3; break;
            case "Cancel": GameManager.I.state = 2; break;
            case "GameStart": GameManager.I.state = 4; break;
            case "PausePressed": GameManager.I.state = 5; break;
            case "GameOver": GameManager.I.state = 6; break;
            case "Restart": GameManager.I.state = 4; break;
            case "FinishPressed": GameManager.I.state = 2; break;
            case "ContinuePressed": GameManager.I.state = 4; break;
            case "Result": GameManager.I.state = 7; break;
            case "ResultToSS": GameManager.I.state = 2; break;
        }

        if (GameManager.I.state == 5)
        {
            UIManager.I.Pause();
        }
        if (GameManager.I.state== 4)
        {
            if (Time.timeScale == 0) Time.timeScale = 1;//일시정지 해제
        }
        GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>().Switcher(GameManager.I.state);
    }

    private void Update()
    {
    }
}
