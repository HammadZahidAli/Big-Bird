using UnityEngine;
using System.Collections;

public class HudMenuManager : MonoBehaviour {

    public GameObject PausePanel;
    public void OnPauseClick()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }

    public void OnResumeClick()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }


    public void OnClickRestart()
    {
        MainMenuManager.Instance.RestartEvent();
        Time.timeScale = 1;
    }

    public void OnClickHomeBack()
    {
        Time.timeScale = 1;
        MainMenuManager.Instance.GameOverHomeEvent();
    }
}
