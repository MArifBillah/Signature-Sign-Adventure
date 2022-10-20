using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public GameObject Player;
    private bool isOnPlatform;

    void Update()
    {
        if(Input.GetKey("space") && isOnPlatform)
        {
            Player.transform.parent = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player.transform.parent = transform;
            Player.GetComponent<playerMovement>().moveSpeed = 14;
            isOnPlatform = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Player.GetComponent<playerMovement>().moveSpeed = 7;
            Player.transform.parent = null;
            isOnPlatform = false;
        }        
    }
}
