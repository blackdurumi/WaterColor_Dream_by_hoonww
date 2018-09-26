using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Player : MonoBehaviour {

    bool isColliding;
	const int side = 6;
    int count;
    public int fin = 0;
    Color MissionColor = GameManager.I.Goal;
    private void OnCollisionEnter(Collision collision)
    {
        if (isColliding) return;
        isColliding = true;
        if (collision.collider.tag == "Tile")
        {
            // 플레이어 이동
            Rigidbody rb = GetComponent<Rigidbody>();
			rb.velocity = new Vector3(0,0,0);
            rb.AddForce(new Vector3(0, 9.836f, 5.679f)*50);

            //스테이지 클리어 여부 판별
            if (collision.collider.GetComponent<MeshRenderer>().materials[0].color == MissionColor)
                Debug.Log("Correct");
            if (collision.collider.GetComponent<MeshRenderer>().materials[0].color == MissionColor && fin==1)
            {
                SaveClear(GameManager.I.stage);
                GameManager.I.bounce_count = count;
                UIManager.I.ChangeState("Result");
            }

            //게임오버 여부 판별
            if (count == 0)
            {
                UIManager.I.ChangeState("GameOver");
            }

            // 플레이어 색깔 갱신
            UnityEngine.Color ChangedColor;
            ChangedColor = (GetComponent<MeshRenderer>().materials[0].color + collision.collider.GetComponent<MeshRenderer>().materials[0].color) / 2.0f;
            GetComponent<MeshRenderer>().materials[0].SetColor("_Color", ChangedColor);

            // 스코프 위치 이동
			GameObject scope = GameObject.Find("Scope");
			scope.transform.position += Vector3.forward * side * 1.9f;

            // 남은 충돌 횟수 ui 갱신
            count--;
            UIManager.I.UpdateCount(count);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Wall")
        {
            Debug.Log("Crash");
            fin = 1 - fin;
        }
    }

    void Start()
    {
        GetComponent<MeshRenderer>().materials[0].SetColor("_Color", new UnityEngine.Color(1.0f, 1.0f, 1.0f));
        count = GameManager.I.count;
        UIManager.I.UpdateCount(count);
    }

    void Update()
    {
        isColliding = false;

        if (transform.position.y < -10) {
            UIManager.I.ChangeState("GameOver");
        }
    }

    void SaveClear(int stage)
    {
        StreamReader sr = new StreamReader(Application.dataPath + "/Resources/GameData/StageResult.txt",false);
        string[] values = new string[6];
        for(int i=1; i<=5; i++)
            values[i] = sr.ReadLine();

        values[stage] = "1";
        sr.Close();

        StreamWriter sw = new StreamWriter(Application.dataPath + "/Resources/GameData/StageResult.txt", false);
        for (int i = 1; i <= 5; i++)
            sw.WriteLine(values[i]);
        sw.Close();
    }
}