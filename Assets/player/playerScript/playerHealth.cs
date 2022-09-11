using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    [Header("Health Indicator")]
    public float playerHP;
    public Slider playerHealthSlider;
    public float playerMaxHP;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthSlider.maxValue = playerMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
        playerHealthSlider.value = playerHP;    
    }

    public void PlayerDamage(int damage){
        // Debug.Log("hey anda mendapatkan damage sebesar " + damage);
        playerHP -= damage;
    }

    public void playerUpgradeHealth(float HealthBooster)
    {
        playerMaxHP += HealthBooster;
        playerHealthSlider.maxValue = playerMaxHP;
    }

    public void playerHeal(int heal){
        if(playerHP <= playerMaxHP)
        {
            playerHP += heal;
            if(playerHP>playerMaxHP)
            {
                playerHP = playerHP - (playerHP-playerMaxHP);
            }
        }
    }
}
