using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundDragOnIce : MonoBehaviour
{

    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.GetComponent<playerMovement>().groundDrag = 0f;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            player.GetComponent<playerMovement>().groundDrag = 5.0f;
        }        
    }
}
