using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //these are from shootingGun.cs
    public float timeBetweenShooting;

    //this is the position of the Player
    public float[] position;

    //saving coin position
    public static List<bool> coinStateSave = new List<bool>();

    public playerDatas (DataConverger player)
    {
        playerHP = player.playerHP;
        playerMaxHP = player.playerMaxHP;
        enemyDestroyedCount = player.enemyDestroyedCount;
        coinCollected = player.coinCollected;
        timeBetweenShooting = player.timeBetweenShooting;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        coinStateSave.Clear();
        coinStateSave.AddRange(coinCollector.coinState);
    }

}
