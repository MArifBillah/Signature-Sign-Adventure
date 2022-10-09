using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataConverger : MonoBehaviour
{
    //step 1 : all data that need to be saved are stored here first
    [Header("Save From These")]
    public GameObject player;
    public GameObject playerObj;
    public GameObject gun;
    public GameObject ShieldBoosting;
    //these are from playerHealth.cs
    public float playerHP;
    public float playerMaxHP;
    //these are from playerScore.cs
    public int enemyDestroyedCount;
    public int coinCollected;
    public int totalCurrency;
    //these are from shootingGun.cs
    public float timeBetweenShooting;
    //these are from shieldBooster.cs
    public int shieldHealth;
    public int shield;
    public bool isShieldActive;

    void Update()
    {
        PlayerHealth();
        PlayerScore();
        ShootingGun();
        ShieldBooster();
    }
    public void PlayerHealth()
    {
        playerHP = playerObj.GetComponent<playerHealth>().playerHP;
        playerMaxHP = playerObj.GetComponent<playerHealth>().playerMaxHP;

    }

    public void PlayerScore()
    {
        enemyDestroyedCount = player.GetComponent<playerScore>().enemyDestroyedCount;
        coinCollected = player.GetComponent<playerScore>().coinCollected;
    }

    public void ShootingGun()
    {
        timeBetweenShooting = gun.GetComponent<shootingGun>().timeBetweenShooting;
    }

    public void ShieldBooster()
    {
        shield = ShieldBoosting.GetComponent<shieldBooster>().shield;
        shieldHealth = ShieldBoosting.GetComponent<shieldBooster>().shieldHealth;
        isShieldActive = ShieldBoosting.GetComponent<shieldBooster>().isShieldActive;
    }

    // public void SaveCurrency()
    // {
    //         playerDatas data = saveSystem.LoadPlayer();
    //         totalCurrency = data.totalCurrency + player.GetComponent<playerScore>().coinCollected;
    //         Debug.Log("my current currency is now = "+totalCurrency);
    // }

    // public void substractCoin(int usedCoin)
    // {
    //     playerDatas data = saveSystem.LoadPlayer();
    //     totalCurrency = data.totalCurrency + usedCoin;
    // }
}
