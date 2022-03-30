using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    public UnityEvent onGameOver;

    private float surviveTime;
    private bool isGameover;

    void Start()
    {
        surviveTime = 0f;
        isGameover = false;
    }

    void Update()
    {
        if (!isGameover)
        {
            surviveTime += Time.deltaTime;
            timeText.text = $"Time:{ (int)surviveTime}";
            timeText.gameObject.SetActive(true);
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene("SampleScene");
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);
        timeText.gameObject.SetActive(false);
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime>bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime",bestTime);
        }

        recordText.text = $"Best Time : {(int)bestTime}";

        onGameOver.Invoke();
    }
}
