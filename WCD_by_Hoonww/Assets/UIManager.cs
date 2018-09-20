using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private static UIManager instance;
    public static UIManager I
    {
        get { return instance; }
    }
    
    void Start ()
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

        ChangeUI();
    }

    public void ChangeState(string name)
    {
        //stage = 0;
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
            Debug.Log("PAUSE");
            UIManager.I.Pause();
        }
        else if (GameManager.I.state == 4)
        {
            if (Time.timeScale == 0) Time.timeScale = 1;//일시정지 해제
        }
        else if (GameManager.I.state == 6)
        {
            GameObject.Find("FadeAnim").GetComponent<FadeAnim>().StartFadeOutAnim();
        }
        GameObject.Find("SceneSwitcher").GetComponent<SceneSwitcher>().Switcher(GameManager.I.state);
    }

    public void WhichStage(int n)
    {
        GameManager.I.stage = n;

        MapParser parser = GameObject.Find("MapParser").GetComponent<MapParser>();
        GameObject.Find("StageNum").GetComponent<Text>().text = n.ToString();

        DS MapData = parser.data;
        parser.Parse();
        GameObject.Find("Limit").GetComponent<Text>().text = MapData.Count.ToString();
        GameManager.I.count = MapData.Count;
    }

    public void UpdateCount(int n)
    {
        GameObject.Find("Count").GetComponent<Text>().text = n.ToString();
    }

    public void ChangeUI()
    {
        GameObject ContinueButton = GameObject.Find("Continue");
        GameObject FinishButton = GameObject.Find("Finish");
        GameObject PauseButton = GameObject.Find("Pause");
        GameObject StartButton = GameObject.Find("Start");
        GameObject StageName = GameObject.Find("StageNum");
        GameObject Popup = GameObject.Find("Popup");
        GameObject WhichStage = GameObject.Find("WhichStage");
        GameObject StageNum = GameObject.Find("StageNum");
        GameObject BounceLimit = GameObject.Find("BounceLimit");
        GameObject Limit = GameObject.Find("Limit");
        GameObject X = GameObject.Find("X");
        GameObject BounceNum = GameObject.Find("BounceNum");

        switch (GameManager.I.state)
        {
            case 2: //스테이지 선택화면
                Popup.GetComponent<Image>().enabled = false;
                WhichStage.GetComponent<Text>().enabled = false;
                StageNum.GetComponent<Text>().enabled = false;
                BounceLimit.GetComponent<Text>().enabled = false;
                Limit.GetComponent<Text>().enabled = false;
                X.GetComponent<Image>().enabled = false;
                X.GetComponentInChildren<Text>().enabled = false;
                StartButton.GetComponent<Button>().interactable = false;
                StartButton.GetComponent<Image>().enabled = false;
                StartButton.GetComponentInChildren<Text>().enabled = false;
                StageName.GetComponent<Text>().enabled = false;
                break;
            case 3: //팝업 화면
                Popup.GetComponent<Image>().enabled = true;
                WhichStage.GetComponent<Text>().enabled = true;
                StageNum.GetComponent<Text>().enabled = true;
                BounceLimit.GetComponent<Text>().enabled = true;
                Limit.GetComponent<Text>().enabled = true;
                X.GetComponent<Image>().enabled = true;
                X.GetComponentInChildren<Text>().enabled = true;
                StartButton.GetComponent<Button>().interactable = true;
                StartButton.GetComponent<Image>().enabled = true;
                StartButton.GetComponentInChildren<Text>().enabled = true;
                StageName.GetComponent<Text>().enabled = true;
                break;
            case 4: //인게임 들어감
                ContinueButton.GetComponent<Image>().enabled = false;
                FinishButton.GetComponent<Image>().enabled = false;
                ContinueButton.GetComponentInChildren<Text>().enabled = false;
                FinishButton.GetComponentInChildren<Text>().enabled = false;
                ContinueButton.GetComponent<Button>().interactable = false;
                FinishButton.GetComponent<Button>().interactable = false;
                break;
            case 7: //결과화면
                BounceNum.GetComponent<Text>().text = (GameManager.I.count - GameManager.I.bounce_count).ToString(); break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
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

    public void UpdateExpectedColorImage(UnityEngine.Color Color)
    {
        Image ExpColor = GameObject.Find("CurrentColor").GetComponent<Image>();

        ExpColor.color = Color;
    }

    // 버튼들 목록
    public void GameStartButton()
    {
        Image MissionColor = GameObject.Find("MissionColor").GetComponent<Image>();

        MissionColor.color = new Color(0.0f, 0.0f, 0.0f); // Mission Color 가져오기 필요
    }

    public void RestartButton()
    {
    }

    public void FinishButton()
    {

    }

    public void ContinueButton()
    {

    }

    public void MenuButton()
    {

    }

    public void LeftButton() //게임상 왼쪽으로 회전버튼
    {

    }

    public void RightButton() //오른쪽으로 회전버튼
    {

    }

    public void ResultPage() //결과화면
    {

    }

    public void UpdateLeftJumping() //인게임에서 남은 점프 횟수 출력
    {

    }

    public void WhichStage() //지금 게임중인게 무슨스테이지인지
    {
    }
}
