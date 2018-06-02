using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateExpectedColorImage(UnityEngine.Color Color)
    {
        Image ExpColor = GameObject.Find("Image").GetComponent<Image>();

        ExpColor.color = Color;
    }

    // 버튼들 목록
    public void GameStartButton()
    {
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
