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
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            string activeScene = SceneManager.GetActiveScene().name;
            endPanel.GetComponent<menuController>().winGame();
            if(activeScene == "level_1")
            {
                menuController.level_1 = true;
                PlayerPrefs.SetInt("level_1_completed", menuController.level_1?1:0);
                menuController.level_2 = true;
                PlayerPrefs.SetInt("level_2_completed", menuController.level_2?1:0);
            }

            if(activeScene == "level_2")
            {
                menuController.level_3 = true;
                PlayerPrefs.SetInt("level_3_completed", menuController.level_3?1:0);
            }

            if(activeScene == "level_3")
            {
                menuController.level_4 = true;
                PlayerPrefs.SetInt("level_4_completed", menuController.level_4?1:0);
            }

            if(activeScene == "level_4")
            {
                
            }
            
         }
    }
}
