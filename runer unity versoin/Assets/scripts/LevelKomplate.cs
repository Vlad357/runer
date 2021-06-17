using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelKomplate : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
