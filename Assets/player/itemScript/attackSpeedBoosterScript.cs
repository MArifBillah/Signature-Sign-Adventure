using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackSpeedBoosterScript : MonoBehaviour
{
    float subsDelay = 0.1f;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("gun").GetComponent<shootingGun>().attackSpeedUpgrade(subsDelay);
            Destroy(gameObject);
        }

    }
}
