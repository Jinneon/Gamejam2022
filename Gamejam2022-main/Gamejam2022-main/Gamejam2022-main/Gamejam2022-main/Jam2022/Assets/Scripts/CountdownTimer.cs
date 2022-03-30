using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class CountdownTimer : MonoBehaviour
{

    float currentTime = 0f;
    float startingTime = 99f;
    public float restartDelay = 5f;

    [SerializeField] TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0.0");

        if (currentTime < 10f) { countdownText.color = Color.red; }

        if(currentTime <= 0)
        {
            currentTime = 0;
            Debug.Log("Game Over");
            GameOver();
            Invoke("GameoOver", restartDelay);
        }
    }

    

    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
