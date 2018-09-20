using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public int state = 1;
    public int stage = 0;
    public int count = 0;
    public int bounce_count = 0;

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
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
    }
}
