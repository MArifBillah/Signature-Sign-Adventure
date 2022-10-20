using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutscene_1 : MonoBehaviour
{
    [Header("Public Variables")]
    public GameObject player;
    public GameObject playerFreeCam;
    public GameObject playerCombatCam;
    public GameObject playerUI;
    public GameObject cutsceneCam;
    public GameObject MainCamera;
    public GameObject triggerBox;
    public GameObject playerObject;
    public bool isActive;
    
    void Start()
    {
        isActive = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {   
            isActive = true;
            player.GetComponent<playerMovement>().walkSound.Stop();
            player.GetComponent<playerMovement>().isAudioPlaying = false;
            playerUI.SetActive(false);
            cutsceneCam.SetActive(true);
            Debug.Log("Process Should start here");  
            playerCombatCam.SetActive(false);
            playerFreeCam.SetActive(false);
            player.GetComponent<playerMovement>().enabled = false;
            MainCamera.GetComponent<TPmove>().enabled = false;
            GameObject.Find("astroguy_running").GetComponent<Animator>().SetBool("isRunning", false);
            
            
        }
    }

    void closeCutscene()
    {
        isActive = false;
        playerUI.SetActive(true);
        cutsceneCam.SetActive(false);
        playerFreeCam.SetActive(true);
        GameObject.Find("Main Camera").GetComponent<TPmove>().enabled = true;
        player.GetComponent<playerMovement>().enabled = true;
        triggerBox.GetComponent<BoxCollider>().enabled = false;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Return) && isActive)
        {
            closeCutscene();
        }
    }


}
