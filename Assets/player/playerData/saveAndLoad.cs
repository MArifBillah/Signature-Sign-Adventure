using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveAndLoad : MonoBehaviour
{

    public GameObject player;
    public GameObject playerObj;
    public GameObject gun;
    public GameObject endPanel;
    public GameObject minigame;
    bool isMainMenu = false;
    public static bool isLoadingProgress = false;
    public static bool isNewGame = false;
    // public static int currency;
    // public GameObject pauseMenu;
    //step 4: now I can use them to save and load data by using these functions
    void Start()
    {
        Debug.Log("script is starting");
        string activeScene = SceneManager.GetActiveScene().name;
        if(activeScene == "mainMenu")
        {
            isMainMenu = true;
        }
       
    }
    void Update()
    {

        //the game will always load the player's progress if its not in main menu and is not a new game
        if(!isMainMenu && isLoadingProgress && !isNewGame)
        {
            //patch work in haste
            Debug.Log("Checked and loaded");
                    Debug.Log("SaveAndLoad is first");
            LoadPlayer();
            isLoadingProgress = false;
            isMainMenu = false;
        }

    
    
    }
    public void SavePlayer()
    {
        DataConverger sendingData = player.GetComponent<DataConverger>();
        //this is where the function to update the currency amount in DataConverger is happening
        // sendingData.SaveCurrency();
        int currencyStored;
        currencyStored = PlayerPrefs.GetInt("currencyStored");
        currencyStored += player.GetComponent<playerScore>().coinCollected;
        PlayerPrefs.SetInt("currencyStored", currencyStored);
        //reset the player score to prevent infinite coins bug
        player.GetComponent<playerScore>().coinCollected = 0;
        saveSystem.SavePlayer(sendingData);
    }

    public void LoadPlayer()
    {
        //to stop player from having infinite amount of coins
        
        // if accessed within the lose game function then it will close the game over panel
        // Debug.Log("trying to load the game");
        string activeScene = SceneManager.GetActiveScene().name;
        if(activeScene == "mainMenu")
        {
            if(PlayerPrefs.HasKey("LevelSaved"))
            {
                isLoadingProgress = true;
                isNewGame = false;
                string levelToLoad = PlayerPrefs.GetString("LevelSaved");
                SceneManager.LoadScene(levelToLoad);
                
            }
        }
        // Debug.Log("The Rest should also be loaded");
        // player.GetComponent<playerScore>().coinCollected = 0;
        endPanel.SetActive(false);
        gameObject.GetComponent<pauseMenu>().resumeGame();
        player.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        playerDatas data = saveSystem.LoadPlayer();
        // Debug.Log(data.playerHP);

        playerObj.GetComponent<playerHealth>().playerHP = data.playerHP;
        playerObj.GetComponent<playerHealth>().playerMaxHP = data.playerMaxHP;
        player.GetComponent<playerScore>().enemyDestroyedCount = data.enemyDestroyedCount;
        player.GetComponent<playerScore>().coinCollected = 0;
        gun.GetComponent<shootingGun>().timeBetweenShooting = data.timeBetweenShooting;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;

        
        // if(playerDatas.coinStateSave.Count > 0)
        // {
        //     Debug.Log("coinstate cleared and added");
        //     coinCollector.coinState = new List<bool>();
        //     coinCollector.coinState.AddRange(playerDatas.coinStateSave);
        // }
    }
}
