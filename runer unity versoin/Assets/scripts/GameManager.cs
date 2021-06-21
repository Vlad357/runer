using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;
using System.IO;

public class GameManager : MonoBehaviour
{
    private bool PauseGame = false;
    private bool EndTheGame = false;
    private string path;

    public static SaveGame SG = new SaveGame();
    public GameObject complateLevelUI;
    public GameObject pauseMenuUI;
    public Text RightSettings;
    public Text LeftSettings;
    public int CountCoin { get; private set; }

    private void Start()
    {
        Time.timeScale = 1;
        path = Path.Combine(Application.dataPath, "SaveGames.json");
        if (!File.Exists(path))
        {
            SG.Coin = 0;
            SG.StringToTheRight = "d";
            FindObjectOfType<PlayerMovemend>().ToTheRight = SG.StringToTheRight;
            SG.StringToTheLeft = "a";
            FindObjectOfType<PlayerMovemend>().ToTheLeft = SG.StringToTheLeft;
        }
        else
        {
            SG = JsonUtility.FromJson<SaveGame>(File.ReadAllText(path));
            CountCoin = SG.Coin;
            if (SG.StringToTheRight != null && SG.StringToTheLeft != null)
            {
                if (SG.StringToTheRight != null)
                {
                    FindObjectOfType<PlayerMovemend>().ToTheRight = SG.StringToTheRight;
                }
                if (SG.StringToTheLeft != null) 
                {
                    FindObjectOfType<PlayerMovemend>().ToTheLeft = SG.StringToTheLeft; 
                }
            }
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
    public void MovRaL()
    {
        RightSettings.text = SG.StringToTheRight;
        LeftSettings.text = SG.StringToTheLeft;
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
    public string StringToTheRight;
    public string StringToTheLeft;
}