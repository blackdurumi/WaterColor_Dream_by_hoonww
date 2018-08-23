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

    public void ChangeUI()
    {
        GameObject ContinueButton = GameObject.Find("Continue");
        GameObject FinishButton = GameObject.Find("Finish");
        GameObject PauseButton = GameObject.Find("Pause");
        GameObject StartButton = GameObject.Find("Start");
        GameObject StageName = GameObject.Find("StageNum");
        GameObject Popup = GameObject.Find("Popup");

        switch (GameManager.I.state)
        {
            case 2:
                Popup.GetComponent<Image>().enabled = false;
                StartButton.GetComponent<Button>().interactable = false;
                StartButton.GetComponent<Image>().enabled = false;
                StartButton.GetComponentInChildren<Text>().enabled = false;
                StageName.GetComponent<Text>().enabled = false;
                break;
            case 3:
                Popup.GetComponent<Image>().enabled = true;
                StartButton.GetComponent<Button>().interactable = true;
                StartButton.GetComponent<Image>().enabled = true;
                StartButton.GetComponentInChildren<Text>().enabled = true;
                StageName.GetComponent<Text>().enabled = true;
                break;
            case 4:
                ContinueButton.GetComponent<Image>().enabled = false;
                FinishButton.GetComponent<Image>().enabled = false;
                ContinueButton.GetComponentInChildren<Text>().enabled = false;
                FinishButton.GetComponentInChildren<Text>().enabled = false;
                ContinueButton.GetComponent<Button>().interactable = false;
                FinishButton.GetComponent<Button>().interactable = false;
                break;
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
        Image ExpColor = GameObject.Find("Image (1)").GetComponent<Image>();

        ExpColor.color = Color;
    }

    // 버튼들 목록
    public void GameStartButton()
    {
        Image MissionColor = GameObject.Find("Image").GetComponent<Image>();

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
