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

    public void loseGame()
    {
        Debug.Log("You lose loser");
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Game Over";
        player.SetActive(false);

        retryButton.SetActive(true);
        restartButton.SetActive(true);
        quitButton.SetActive(true);
        
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void winGame()
    {
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Win";
    }
}

