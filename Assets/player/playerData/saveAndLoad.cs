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
    public GameObject shieldBoost;
    bool isMainMenu = false;
    public static bool isLoadingProgress = false;
    public static bool isNewGame;
    // public static int currency;
    // public GameObject pauseMenu;
    //step 4: now I can use them to save and load data by using these functions
    int whichLevel;
    void Start()
    {
        Debug.Log("script is starting");
        string activeScene = SceneManager.GetActiveScene().name;
        if(activeScene == "mainMenu")
        {
            isMainMenu = true;
        }
        else if(activeScene == "level_1")
        {
            whichLevel = 0;
        }
        else if(activeScene == "level_2")
        {
            whichLevel = 1;
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
        else if(isNewGame){
                coinCollector.coinState[whichLevel].Clear();
                isNewGame = false;
        }
    }

    public void SavePlayer()
    {
        DataConverger sendingData = player.GetComponent<DataConverger>();
        //this is where the function to update the currency amount in DataConverger is happening
        int currencyStored;
        currencyStored = PlayerPrefs.GetInt("currencyStored");
        currencyStored += player.GetComponent<playerScore>().coinCollected;
        PlayerPrefs.SetInt("currencyStored", currencyStored);
        //reset the player score to prevent infinite coins bug
        player.GetComponent<playerScore>().coinCollected = 0;
        saveSystem.SavePlayer(sendingData);

    }

    // List<bool> coinStateSaveLoad = new List<bool>();
    public void LoadPlayer()
    {
        // isNewGame = false;
        coinCollector.counter = 0;
        //to stop player from having infinite amount of coins
        
        // if accessed within the lose game function then it will close the game over panel
        // Debug.Log("trying to load the game");
        string activeScene = SceneManager.GetActiveScene().name;
        if(activeScene == "mainMenu")
        {
            if(PlayerPrefs.HasKey("LevelSaved"))
            {
                Debug.Log("Level loaded");
                isLoadingProgress = true;
                // isNewGame = false;
                string levelToLoad = PlayerPrefs.GetString("LevelSaved");
                SceneManager.LoadScene(levelToLoad);
                
            }
        }
        
        endPanel.SetActive(false);
        gameObject.GetComponent<pauseMenu>().resumeGame();
        player.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        playerDatas data = saveSystem.LoadPlayer();
        
        
        playerObj.GetComponent<playerHealth>().playerHP = data.playerHP;
        playerObj.GetComponent<playerHealth>().playerMaxHP = data.playerMaxHP;
        player.GetComponent<playerScore>().enemyDestroyedCount = data.enemyDestroyedCount;
        player.GetComponent<playerScore>().coinCollected = 0;
        gun.GetComponent<shootingGun>().timeBetweenShooting = data.timeBetweenShooting;
        shieldBoost.GetComponent<shieldBooster>().shield = data.shield;
        shieldBoost.GetComponent<shieldBooster>().shieldHealth = data.shieldHealth;
         shieldBoost.GetComponent<shieldBooster>().isShieldActive = data.isShieldActive;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;

        // coinStateSaveLoad = new List<bool>();
        // coinStateSaveLoad.AddRange(data.coinStateSave);

        Debug.Log("the length of coinstatesave is = "+data.coinStateSave[whichLevel].Count);
        //  Debug.Log("the length of coinstatesave is = "+coinCollector.coinState[0].Count);
        // data.coinStateSave[0] = true;
        // Debug.Log("This is the state of data.coinStateSave = "+ data.coinStateSave[0][0]);
        Debug.Log("The Rest should also be loaded");


        if(data.coinStateSave[whichLevel].Count > 0 )
        {
            
            Debug.Log("coinstate cleared and added");
                coinCollector.coinState[whichLevel].Clear();
                coinCollector.coinState[whichLevel].AddRange(data.coinStateSave[whichLevel]);
                Debug.Log("saved level "+whichLevel);
            // coinCollector.coinState.AddRange(data.coinStateSave);
            // Debug.Log("This is the state of coinCollector.coinState = "+ coinCollector.coinState[106]);
            // Debug.Log("the length of coinstatesave is = "+coinCollector.coinState.Count);

        }
    }
}
