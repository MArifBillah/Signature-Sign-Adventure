using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerHealth : MonoBehaviour
{

    [Header("Health Indicator")]
    public float playerHP;
    public Slider playerHealthSlider;
    public float playerMaxHP;
    public TextMeshProUGUI healthText;
    public GameObject endPanel;

    // Start is called before the first frame update
    void Start()
    {
        playerHealthSlider.maxValue = playerMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
        playerHealthSlider.value = playerHP;
        healthText.text = playerHP.ToString();
        if(playerHP<=0)
        {
            playerLose();
        }    
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

    public void playerLose()
    {
        endPanel.GetComponent<menuController>().loseGame();
    }
}
