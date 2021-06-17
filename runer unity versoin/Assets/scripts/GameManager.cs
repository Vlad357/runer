using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool EndTheGame = false;

    public GameObject complateLevelUI;

    public void CompleteLevel()
    {
        complateLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if(EndTheGame == false)
        {
            Debug.Log("Game Over");
            EndTheGame = true;
            Invoke("Restart", 1.5f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
