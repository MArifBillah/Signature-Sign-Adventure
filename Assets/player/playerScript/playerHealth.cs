using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    [Header("Health Indicator")]
    public float playerHP;
    public Slider playerHealthSlider;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
