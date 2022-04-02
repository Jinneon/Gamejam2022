using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
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
            ph.heartImages[0].sprite = ph.noHeart;
            gameoverText.gameObject.SetActive(true);
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2f);
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    
}
