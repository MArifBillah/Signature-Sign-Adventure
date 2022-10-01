using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class menuController : MonoBehaviour
{
    [SerializeField]
    private string newGameLevel;

    public GameObject endPanel;
    public GameObject player;

    public GameObject retryButton;
    public GameObject restartButton;
    public GameObject quitButton;
    public GameObject nextLevelButton;

    public static bool level_1 = false, level_2 = false, level_3 = false, level_4 = false;

    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void LoadGameButton()
    {
        if(PlayerPrefs.HasKey("LevelSaved"))
        {
            string levelToLoad = PlayerPrefs.GetString("LevelSaved");
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public void LoadGameLevelOne()
    {
        SceneManager.LoadScene("level_1");
    }

    public void LoadGameLevelTwo()
    {
        if(level_1)
        {
            SceneManager.LoadScene("level_2");
        }
        
    }

    public void LoadGameLevelThree()
    {
        if(level_2)
        {
            SceneManager.LoadScene("level_3");
        }
        
    }

    public void LoadGameLevelFour()
    {
        if(level_3)
        {
            SceneManager.LoadScene("level_4");
        }
        
    }

    public void loseGame()
    {
        Debug.Log("You lose loser");
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Game Over";
        player.SetActive(false);

        retryButton.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);
        nextLevelButton.SetActive(false);
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void winGame()
    {
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Win";

        player.SetActive(false);
        nextLevelButton.SetActive(true);
        retryButton.SetActive(false);
        restartButton.SetActive(false);
        quitButton.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}

