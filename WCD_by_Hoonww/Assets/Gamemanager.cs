using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    public int state = 1;


    public void Start()
    {
        GameObject ContinueButton = GameObject.Find("Continue");
        GameObject FinishButton = GameObject.Find("Finish");
        GameObject PauseButton = GameObject.Find("Pause");

        if (ContinueButton != null)
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
        switch (name)
        {
            case "GameResetFin": state = 2; break;
            case "StartButtonPressed": state = 3; break;
            case "StageResetFin": state = 5; break;
            case "MenuPressed": state = 7; break;
            case "GameOver": state=6; break;
            case "StageClear": state=11; break;
            case "GOtoSS": state = 4; break; //GOtoSS == GameOver to StageSelect
            case "RestartPressed": state = 8; break;
            case "FinishPressed": state = 9; break;
            case "ContinuePressed": state = 10; break;
            case "Restart": state = 4; break;
            case "Result": state = 12; break;
            case "GameQuit": state = 3; break;
            case "Continue": state = 5; break;
            case "FinishDataSaved": state = 12; break;
            case "ResultToSS": state = 3; break;
        }
        if (state == 4)
        {
            //초기화 작업
            state = 3;
        }
        if (state == 9)
        {
            if (Time.timeScale == 0) Time.timeScale = 1;
            state = 3;
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
