using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class playerDatas
{
    //step 2 : all datas from the DataConverger script are stored into the playerDatas constructor
    //these are from playerHealth.cs
    public float playerHP;
    public float playerMaxHP;
    //these are from playerScore.cs
    public int enemyDestroyedCount;
    public int coinCollected;
    //this one is for the store feature
    // public int totalCurrency;
    //these are from shootingGun.cs
    public float timeBetweenShooting;

    //these are from shieldBooster
    public int shield;
    public int shieldHealth;
    public bool isShieldActive;
    //this is the position of the Player
    public float[] position;


    //saving coin position
    public List<List<bool>> coinStateSave = new List<List<bool>>();

    public playerDatas (DataConverger player)
    {
        playerHP = player.playerHP;
        playerMaxHP = player.playerMaxHP;
        enemyDestroyedCount = player.enemyDestroyedCount;
        coinCollected = player.coinCollected;
        timeBetweenShooting = player.timeBetweenShooting;
        // totalCurrency = player.totalCurrency;
        shield = player.shield;
        shieldHealth = player.shieldHealth;
        isShieldActive = player.isShieldActive;

        position = new float[3];
        position[0] = player.transform.position.x +2;
        position[1] = player.transform.position.y+2;
        position[2] = player.transform.position.z+2;

        if(coinStateSave.Count < 2)
        {
            coinStateSave.Add(new List<bool>());
            coinStateSave.Add(new List<bool>());
        }
        
        string activeScene = SceneManager.GetActiveScene().name;
        if(activeScene == "level_1")
        {
            coinStateSave[0].Clear();
            coinStateSave[0].AddRange(coinCollector.coinState[0]);
            Debug.Log("saved level 1");
        }
        else if(activeScene == "level_2")
        {
            coinStateSave[1].Clear();
            coinStateSave[1].AddRange(coinCollector.coinState[1]);
        }
        else if(activeScene == "level_3")
        {
            coinStateSave[2].Clear();
            coinStateSave[2].AddRange(coinCollector.coinState[2]);
        }
        else if(activeScene == "level_4")
        {
            coinStateSave[3].Clear();
            coinStateSave[3].AddRange(coinCollector.coinState[3]);
        }
    }

}
