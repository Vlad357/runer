using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseLevel : MonoBehaviour
{
    public GameObject panel;
    public void ContinueGame()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
