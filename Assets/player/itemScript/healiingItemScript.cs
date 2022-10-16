using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healiingItemScript : MonoBehaviour
{
    int heal = 20;
    public AudioSource healSound;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            healSound.Play();
            GameObject.Find("playerObject").GetComponent<playerHealth>().playerHeal(heal);
            Destroy(gameObject);
        }

    }
}
