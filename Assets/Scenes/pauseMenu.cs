using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject hintPanel;
    public static bool isPause;
    public static bool isHint;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape) && !powerBoostMachine.isInMinigame)
        {
            if(isPause)
            {
                resumeGame();
            }
            else
            {
                closeHintPanel();
                pauseGame();
            }
        }

        if(Input.GetKeyDown(KeyCode.Tab) && !isPause && !powerBoostMachine.isInMinigame)
        {
            if(isHint)
            {
                closeHintPanel();
            }
            else
            {
                openHintPanel();
            }
        }
    }

    public void openHintPanel()
    {
        hintPanel.SetActive(true);
        isHint = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void closeHintPanel()
    {
        hintPanel.SetActive(false);
        isHint = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void pauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale =0f;
        isPause = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void resumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale =1f;
        isPause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void goToMainMenu()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("mainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
