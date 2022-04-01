using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GuiManager : MonoBehaviour
{
    public GameObject panel;

    public void onClickStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void onClickOption()
    {
        panel.SetActive(true);
    }

    public void onClickXbutton()
    {
        panel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            onClickOption();
    }
}
