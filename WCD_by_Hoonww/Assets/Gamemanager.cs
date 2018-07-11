using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    [SerializeField]
    private bool GSButtonPressed = false;
    private bool StageSelected = false;
    private bool MenuPressed = false;
    private bool GameOver = false;
    private bool RestartPressed = false;
    private bool FinishPressed = false;
    private bool ContinuePressed = false;

    public int state = 1;

    public void ChangeState(string name)
    {
        switch (name)
        {
            case "GameOver": state=6; break;
            case "StageClear": state=11; break;
            case "Result": state = 12; break;
        }
    }

    private void Update()
    {
       /* switch (state)
        {
            case 1: //게임 초기화
                state = 2;
                break;

            case 2: //메인 화면
                if (GSButtonPressed) state = 3;
                break;

            case 3: //스테이지 선택
                if (StageSelected) state = 4;
                break;

            case 4: //스테이지 초기화
                state = 5;
                break;

            case 5: //게임 진행
                if (MenuPressed) state = 7;
                if (GameOver) state = 6;

                state = 11;
                break;

            case 6: //게임 오버
                state = 4;
                break;

            case 7: //메뉴 화면
                if (RestartPressed) state = 8;
                if (FinishPressed) state = 9;
                if (ContinuePressed) state = 10;
                break;

            case 8: //다시하기
                state = 4;
                break;

            case 9: //그만하기
                state = 3;
                break;

            case 10: //계속하기
                state = 5;
                break;

            case 11: //게임 클리어
                state = 12;
                break;

            case 12: //결과 화면
                state = 3;
                break;
        }*/
    }
}
