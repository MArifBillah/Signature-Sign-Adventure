using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackSpeedBoosterScript : MonoBehaviour
{
    float subsDelay = 0.3f;
    public AudioSource upgrade;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            upgrade.Play();
            GameObject.Find("gun").GetComponent<shootingGun>().attackSpeedUpgrade(subsDelay);
            Destroy(gameObject);
        }

    }
}
