using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalScript : MonoBehaviour
{
    public GameObject endPanel;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            string activeScene = SceneManager.GetActiveScene().name;
            endPanel.GetComponent<menuController>().winGame();
            if(activeScene == "level_1")
            {
                menuController.level_1 = true;
            }

            if(activeScene == "level_2")
            {
                menuController.level_2 = true;
            }

            if(activeScene == "level_3")
            {
                menuController.level_3 = true;
            }

            if(activeScene == "level_4")
            {
                menuController.level_4 = true;
            }
            
         }
    }
}
