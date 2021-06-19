using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public GameObject panel;
    public void ContinueGame()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
    }
    public void ToMainManu()
    {
        SceneManager.LoadScene("main manu");
    }
    public void Quid()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level01");
    }
}
