using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public GameObject Player;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Player.transform.parent = null;
        }        
    }
}
