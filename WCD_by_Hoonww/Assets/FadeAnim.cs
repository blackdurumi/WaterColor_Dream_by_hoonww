using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnim : MonoBehaviour {

    public float animTime = 2f;

    private Image fadeImage;

    private float start = 0f;
    private float end = 1f;
    private float time = 0f;

    private bool isPlaying = false;

    // Use this for initialization
    void Start()
    {
        fadeImage = GetComponent<Image>();
    }

    public void StartFadeOutAnim()
    {
        if (!isPlaying)
        {
            StartCoroutine("PlayFadeOut");
        }
    }

    IEnumerator PlayFadeOut()
    {
        isPlaying = true;
        
        Color color = fadeImage.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);

        while (color.a < 1f)
        {
            time += Time.deltaTime / animTime;

            color.a = Mathf.Lerp(start, end, time);
            fadeImage.color = color;

            yield return null;
        }

        isPlaying = false;
        UIManager.I.ChangeState("Restart");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
