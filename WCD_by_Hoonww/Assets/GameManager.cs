using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public int state = 1;
    public int stage = 0;

    public void Start()
    {
        GameObject ContinueButton = GameObject.Find("Continue");
        GameObject FinishButton = GameObject.Find("Finish");
        GameObject PauseButton = GameObject.Find("Pause");
        GameObject StartButton = GameObject.Find("Start");
        GameObject StageName = GameObject.Find("Which");

        if (state == 2)
        {
            StartButton.GetComponent<Button>().interactable = false;
            StartButton.GetComponent<Image>().enabled = false;
            StartButton.GetComponentInChildren<Text>().enabled = false;
            StageName.GetComponent<Text>().enabled = false;
        }
        else if (state == 3)
        {
            StartButton.GetComponent<Button>().interactable = true;
            StartButton.GetComponent<Image>().enabled = true;
            StartButton.GetComponentInChildren<Text>().enabled = true;
            StageName.GetComponent<Text>().enabled = true;
        }
        if (state==4)
        {
            ContinueButton.GetComponent<Image>().enabled = false;
            FinishButton.GetComponent<Image>().enabled = false;
            ContinueButton.GetComponentInChildren<Text>().enabled = false;
            FinishButton.GetComponentInChildren<Text>().enabled = false;
            ContinueButton.GetComponent<Button>().interactable = false;
            FinishButton.GetComponent<Button>().interactable = false;
        }
    }

    public void ChangeState(string name)
    {
        //stage = 0;
        switch (name)
        {
            case "StartButtonPressed": state = 2; break;
            case "Stage1Selected": state = 3; stage = 1; break;
            case "Stage2Selected": state = 3; stage = 2; break;
            case "Stage3Selected": state = 3; stage = 3; break;
            case "Stage4Selected": state = 3; stage = 4; break;
            case "Stage5Selected": state = 3; stage = 5; break;
            case "GameStart": state = 4; break;
            case "PausePressed": state = 5; break;
            case "GameOver": state = 6; break;
            case "Restart": state = 4; break;
            case "FinishPressed": state = 2; break;
            case "ContinuePressed": state = 4; break;
            case "Result": state = 7; break;
            case "ResultToSS": state = 2; break;
        }

        if (state == 5)
        {
            Pause();
        }
        if (state == 4)
        {
            if (Time.timeScale == 0) Time.timeScale = 1;//일시정지 해제
        }
        GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>().Switcher(state);
    }

    public void Pause()
    {
        GameObject ContinueButton = GameObject.Find("Continue");
        GameObject FinishButton = GameObject.Find("Finish");
        GameObject PauseButton = GameObject.Find("Pause");

        Time.timeScale = 0;
        PauseButton.GetComponent<Image>().enabled = false;
        ContinueButton.GetComponent<Image>().enabled = true;
        FinishButton.GetComponent<Image>().enabled = true;
        PauseButton.GetComponentInChildren<Text>().enabled = false;
        ContinueButton.GetComponentInChildren<Text>().enabled = true;
        FinishButton.GetComponentInChildren<Text>().enabled = true;
        PauseButton.GetComponent<Button>().interactable = false;
        ContinueButton.GetComponent<Button>().interactable = true;
        FinishButton.GetComponent<Button>().interactable = true;
    }

    public void Continue()
    {
        GameObject ContinueButton = GameObject.Find("Continue");
        GameObject FinishButton = GameObject.Find("Finish");
        GameObject PauseButton = GameObject.Find("Pause");

        Time.timeScale = 1;
        PauseButton.GetComponent<Image>().enabled = true;
        ContinueButton.GetComponent<Image>().enabled = false;
        FinishButton.GetComponent<Image>().enabled = false;
        PauseButton.GetComponentInChildren<Text>().enabled = true;
        ContinueButton.GetComponentInChildren<Text>().enabled = false;
        FinishButton.GetComponentInChildren<Text>().enabled = false;
        PauseButton.GetComponent<Button>().interactable = true;
        ContinueButton.GetComponent<Button>().interactable = false;
        FinishButton.GetComponent<Button>().interactable = false;
    }

    private void Update()
    {
    }
}
