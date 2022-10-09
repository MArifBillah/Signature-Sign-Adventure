using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldItem : MonoBehaviour
{
    public GameObject shieldBoosterPlayer;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            shieldBoosterPlayer.GetComponent<shieldBooster>().shield++;
            Destroy(gameObject);
        }
    }
}
