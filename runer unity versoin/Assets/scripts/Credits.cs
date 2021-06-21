using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Credits : MonoBehaviour
{
    public Animator anim;
    public GameObject settigspanel;
    public void StartGame()
    {
        SceneManager.LoadScene("Level01");
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    public void Settings()
    {
        gameObject.SetActive(false);
        settigspanel.SetActive(true);
    }
    public void ToMainManu()
    {
        SceneManager.LoadScene("main manu");
    }
    public void Quid()
    {
        Application.Quit();
    }
}
