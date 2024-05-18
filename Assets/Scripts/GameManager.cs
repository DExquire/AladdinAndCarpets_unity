using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject gameScreen;
    public GameObject gameWinScreen;
    public GameObject gameOverScreen;
    public GameObject gameButtons;
    public Button playButton;
    public int scoreNum;
    public List<Text> scoreTxt;
    public List<GameObject> columns;
    public Game gameShop;
    public float lives;
    public float startLives;
    public Text livesText;
    public Text coinsText;
    public int armorTime;
    public GameObject effectObject;

    void Start()
    {
        foreach (GameObject column in columns)
        {
            column.SetActive(false);
        }
        menuScreen.SetActive(true);
        gameScreen.SetActive(false);
        gameButtons.SetActive(false);
        playButton.onClick.AddListener(StartGame);
        gameShop.Coins = PlayerPrefs.GetInt("coins");
        coinsText.text = gameShop.Coins.ToString();
        armorTime = PlayerPrefs.GetInt("armor");
        int armor = armorTime / 3;
        for (int i = 0; i < effectObject.transform.childCount; i++)
        {
            if(i+1 <= armor)
            {
                effectObject.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                effectObject.transform.GetChild(i).gameObject.SetActive(false);
            }
            
        }
    }

   
    void Update()
    {
       
    }

    public void StartGame()
    {
        scoreNum = 0;
        /*      foreach(Text score in scoreTxt)
              {
                  score.text = scoreNum.ToString();
              }*/
        Time.timeScale = 1;
        menuScreen.SetActive(false);
        foreach (GameObject column in columns)
        {
            column.SetActive(true);
        }
        gameScreen.SetActive(true);
        gameButtons.SetActive(true);
        lives = startLives;
        livesText.text = lives.ToString();

        for (int i = 0; i < effectObject.transform.childCount; i++)
        {
            if (i < armorTime / 3)
                effectObject.transform.GetChild(i).gameObject.SetActive(true);
            else
                effectObject.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }


    public void GameWin()
    {
        gameScreen.SetActive(false);
        gameWinScreen.SetActive(true);
     //   Invoke("LoadMenu", 3);
    }

    public void GameLose()
    {
        gameOverScreen.SetActive(true);
        gameScreen.SetActive(false);
     //   Invoke("LoadMenu", 3);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("main");
    }
}
