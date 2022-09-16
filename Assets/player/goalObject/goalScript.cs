using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalScript : MonoBehaviour
{
    public GameObject endPanel;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            endPanel.GetComponent<menuController>().winGame();
        }
    }
}
