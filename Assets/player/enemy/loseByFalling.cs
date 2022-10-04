using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseByFalling : MonoBehaviour
{
    public GameObject playerObj;
    
    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            playerObj.GetComponent<playerHealth>().playerHP = 0;
        }
    }
}
