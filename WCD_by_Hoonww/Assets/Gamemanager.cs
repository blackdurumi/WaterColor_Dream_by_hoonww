using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public int state = 1;

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
    }

    private void Update()
    {
    }
}
