using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldItem : MonoBehaviour
{
    public GameObject shieldBoosterPlayer;
    public AudioSource shieldAdded;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            shieldAdded.Play();
            shieldBoosterPlayer.GetComponent<shieldBooster>().shield++;
            Destroy(gameObject);
        }
    }
}
