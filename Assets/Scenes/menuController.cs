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
    public GameObject gameManager;
    public GameObject retryButton;
    public GameObject restartButton;
    public GameObject quitButton;
    public GameObject nextLevelButton;

    public static bool level_1 = true, level_2 = false, level_3 = false, level_4= false, level_5= false;

    public void NewGameButton()
    {
        saveAndLoad.isNewGame = true;
        SceneManager.LoadScene(newGameLevel);
        // coinCollector.coinState.Clear();
    }

    public void LoadGameButton()
    {
        if(PlayerPrefs.HasKey("LevelSaved"))
        {
            saveAndLoad.isNewGame = false;
            saveAndLoad.isLoadingProgress = true;
            string levelToLoad = PlayerPrefs.GetString("LevelSaved");
            SceneManager.LoadScene(levelToLoad);
            //the progress of the player will be loaded through the saveAndLoad script
        }
    }

    public void LoadGameLevelOne()
    {
        saveAndLoad.isNewGame = true;
        SceneManager.LoadScene("level_1");
    }

    public void LoadGameLevelTwo()
    {
        if(level_1)
        {
            saveAndLoad.isNewGame = true;
            SceneManager.LoadScene("level_2");
        }
        
    }

    public void LoadGameLevelThree()
    {
        if(level_2)
        {
            saveAndLoad.isNewGame = true;
            SceneManager.LoadScene("level_3");
        }
        
    }

    public void LoadGameLevelFour()
    {
        if(level_3)
        {
            saveAndLoad.isNewGame = true;
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

        //these will save the amount of currency collected
        //infinite coin bug alert

        gameManager.GetComponent<saveAndLoad>().SavePlayer();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}

