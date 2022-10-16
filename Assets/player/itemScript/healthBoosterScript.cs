using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBoosterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float addMaxHealth;
    public AudioSource upgrade;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            upgrade.Play();
            GameObject.Find("playerObject").GetComponent<playerHealth>().playerUpgradeHealth(addMaxHealth);
            Destroy(gameObject);
        }

    }

}
