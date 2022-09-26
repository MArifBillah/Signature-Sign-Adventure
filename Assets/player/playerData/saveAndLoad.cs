using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveAndLoad : MonoBehaviour
{

    public GameObject player;
    public GameObject playerObj;
    public GameObject gun;
    //step 4: now I can use them to save and load data by using these functions
    public void SavePlayer()
    {
        DataConverger sendingData = player.GetComponent<DataConverger>();
        saveSystem.SavePlayer(sendingData);
        Debug.Log("data saved" +sendingData.playerHP);
    }

    public void LoadPlayer()
    {
        playerDatas data = saveSystem.LoadPlayer();
        Debug.Log(data.playerHP);

        playerObj.GetComponent<playerHealth>().playerHP = data.playerHP;
        playerObj.GetComponent<playerHealth>().playerMaxHP = data.playerMaxHP;
        player.GetComponent<playerScore>().enemyDestroyedCount = data.enemyDestroyedCount;
        player.GetComponent<playerScore>().coinCollected = data.coinCollected;
        gun.GetComponent<shootingGun>().timeBetweenShooting = data.timeBetweenShooting;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;

        coinCollector.coinState.Clear();
        coinCollector.coinState.AddRange(playerDatas.coinStateSave);

    }
}
