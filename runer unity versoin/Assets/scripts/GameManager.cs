using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class GameManager : MonoBehaviour
{
    private bool PauseGame = false;
    private bool EndTheGame = false;
    private SaveGame SG = new SaveGame();
    private string path;

    public GameObject complateLevelUI;
    public GameObject pauseMenuUI;
    public int CountCoin { get; private set; }

    private void Start()
    {
        Time.timeScale = 1;
        path = Path.Combine(Application.dataPath, "SaveGames.json");
        if (!File.Exists(path))SG.Coin = 0;
        else
        {
            SG = JsonUtility.FromJson<SaveGame>(File.ReadAllText(path));
            CountCoin = SG.Coin;
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseGame)
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0;
                PauseGame = true;
                Save();
            }
            else
            {
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1;
                PauseGame = false;
            }
        }
    }
   

    private void Save()
    {
        File.WriteAllText(path, JsonUtility.ToJson(SG));
    }

    public void CollectACoin()
    {
        SG.Coin += 1;
        CountCoin = SG.Coin;
        Debug.Log(SG.Coin);
    }

    public void CompleteLevel()
    {
        complateLevelUI.SetActive(true);
        Save();
    }
    public void EndGame()
    {
        if(EndTheGame == false)
        {
            Debug.Log("Game Over");
            EndTheGame = true;
            Invoke("Restart", 1.5f);
            Save();
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

[Serializable]
public class SaveGame
{
    public int Coin;
    public KeyCode ToTheRight;
    public KeyCode ToTheLeft;
    public KeyCode OnPause;
}
