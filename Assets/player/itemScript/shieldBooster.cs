using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shieldBooster : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource shieldSound;
    public AudioSource shieldSoundImpact;
    public int shieldHealth;
    public int shield;
    public bool isShieldActive;
    public Slider shieldSlider;
    public TextMeshProUGUI shieldHealthText;
    public TextMeshProUGUI shieldChanceText;
    // Update is called once per frame
    void Start()
    {
        isShieldActive = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    
    void Update()
    {
        // Debug.Log(isShieldActive);
        if(isShieldActive)
        {
            shieldSlider.gameObject.SetActive(true);
            gameObject.GetComponent<BoxCollider>().enabled = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else if(!isShieldActive)
        {
            destroyShield();
        }
        shieldSlider.value = shieldHealth;
        shieldHealthText.text = shieldHealth.ToString();
        shieldChanceText.text = shield.ToString();

        if(Input.GetKey(KeyCode.E) && shield > 0 && !powerBoostMachine.isInMinigame && !isShieldActive)
        {
            shieldSound.Play();
            Debug.Log("Shield activated");
            shield--;
            isShieldActive = true;
        }
        
        if(shieldHealth <= 0)
        {
            destroyShield();
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "bullet")
        {
            shieldSoundImpact.Play();
            shieldHealth -= 10;
            Destroy(other);
        }
    }

    void destroyShield()
    {
            shieldHealth = 100;
            isShieldActive = false;
            shieldSlider.gameObject.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
