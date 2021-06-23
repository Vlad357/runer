using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;
using System.IO;

public class GameManager : MonoBehaviour
{

    public SaveGame SG = new SaveGame();
    public GameObject ComplateLevelUI;
    public GameObject PauseMenuUI;
    public GameObject SettindsMenuUI;
    public GameObject RightBtns;
    public GameObject LeftBtns;

    private bool PauseGame = false;
    private bool SettingMenu = false;
    private bool EndTheGame = false;
    private string path;

    public int CountCoin { get; private set; }

    private void Start()
    {
        Time.timeScale = 1;
        path = Path.Combine(Application.dataPath, "SaveGames.json");
        if (!File.Exists(path))
        {
            SG.Coin = 0;
            SG.StringToTheRight = FindObjectOfType<PlayerMovemend>().ToTheRight;
            SG.StringToTheLeft = FindObjectOfType<PlayerMovemend>().ToTheLeft;
        }
        else
        {
            SG = JsonUtility.FromJson<SaveGame>(File.ReadAllText(path));
            CountCoin = SG.Coin;
            if (SG.StringToTheRight != null)
            {
                RightBtns.GetComponent<Text>().text = SG.StringToTheRight;
                FindObjectOfType<PlayerMovemend>().ToTheRight = SG.StringToTheRight;
            }
            if (SG.StringToTheLeft != null) 
            {
                LeftBtns.GetComponent<Text>().text = SG.StringToTheLeft;
                FindObjectOfType<PlayerMovemend>().ToTheLeft = SG.StringToTheLeft;
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseGame && Time.timeScale ==1)
            {
                PauseMenuUI.SetActive(true);
                Time.timeScale = 0;
                PauseGame = true;
                Save();
            }
            if (!SettingMenu)
            {
                SettindsMenuUI.SetActive(false);
                PauseMenuUI.SetActive(true);
            }
            else
            {
                PauseMenuUI.SetActive(false);
                Time.timeScale = 1;
                PauseGame = false;
            }
        }
    }
    public void BtnsRight(string Right)
    {
        SG.StringToTheRight = Right;
        Save();
    }
    public void BtnsLeft(string Left)
    {
        SG.StringToTheLeft = Left;
        Save();
    }
    private void Save()
    {
        File.WriteAllText(path, JsonUtility.ToJson(SG));
    }
    public void CollectACoin()
    {
        SG.Coin += 1;
        CountCoin = SG.Coin;
    }
    public void CompleteLevel()
    {
        ComplateLevelUI.SetActive(true);
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
        Save();
    }
}

[Serializable]
public class SaveGame
{
    public int Coin;
    public string StringToTheRight;
    public string StringToTheLeft;
}