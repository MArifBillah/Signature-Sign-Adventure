using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player"))
        {
            string activeScene = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("LevelSaved", activeScene);

            Debug.Log(activeScene);
            gameObject.SetActive(false);
        }
    }

}
