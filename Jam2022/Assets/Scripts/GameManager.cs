using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth ph;
    public Text gameoverText;
    public UnityEvent even;

    static GameManager _instance = null;
    void Start()
    {
        _instance = this;
    }

    public static GameManager GetInstance()
    {
        return _instance;
    }

    public void GameOver()
    {
        if (ph.isCharacterDead)
        {
            gameoverText.gameObject.SetActive(true);
            player.SetActive(false);
            Time.timeScale = 0;
        }
    }
}
