using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerBoostMachine : MonoBehaviour
{
    public GameObject player;
    public GameObject playerFreeCam;
    public GameObject playerCombatCam;
    public GameObject boosterCam;
    public GameObject triggerBox;
    [Header("Ganti Texture ini")]
    Texture m_MainTexture;
    public Texture defaultTexture;
    public Texture A;
    public Texture B;
    public Texture C;
    int randomNumber;
    bool choice = false;
    KeyCode jawab;
    
    Renderer m_Renderer;

    public GameObject changeThisTexture;
    
    // private Animator anim;
    void OnTriggerEnter(Collider other)
    {
        changeTexture();
        triggerBox.GetComponent<BoxCollider>().enabled = false;
        boosterCam.SetActive(true);
        playerCombatCam.SetActive(false);
        playerFreeCam.SetActive(false);

        GameObject.FindWithTag("Player").GetComponent<playerMovement>().enabled = false;
        GameObject.Find("Main Camera").GetComponent<TPmove>().enabled = false;
        // GameObject.Find("Main Camera").GetComponent<lookAtCam>().cheese(); //nanti diperbaiki lagi
        GameObject.Find("astroguy_running").GetComponent<Animator>().SetBool("isRunning", false);
    }

    private void Update()
    {
        if(choice)
        {
            
            if(Input.GetKeyDown(jawab))
            {
                
                Debug.Log("jawaban benar");
                cancelBooster();
                choice = false;
            }

            if(Input.GetKey(KeyCode.Escape))
            {
                Debug.Log("keluar dari booster");
                choice = false;
                cancelBooster();
            }          
        }

    }

    public void cancelBooster()
    {
        changeThisTexture.GetComponent<Renderer>().material.SetTexture("_MainTex", defaultTexture);
        playerFreeCam.SetActive(true);
        boosterCam.SetActive(false);
        GameObject.Find("Main Camera").GetComponent<TPmove>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<playerMovement>().enabled = true;
        
    }


    public void changeTexture()
    {
        Debug.Log("texture changed");
        choice = true;
        randomNumber = Random.Range(1, 4);
        //Fetch the Renderer from the GameObject
        m_Renderer = changeThisTexture.GetComponent<Renderer> ();
        Debug.Log("nomor randomnya adalah ="+randomNumber);
        switch (randomNumber)
        {
            case 1:
                m_MainTexture = A;
                jawab = KeyCode.A;
                Debug.Log("texture changed to A");
                break;
            case 2:
                m_MainTexture = B;
                jawab = KeyCode.B;
                Debug.Log("texture changed to B");
                break;
            case 3:
                m_MainTexture = C;
                jawab = KeyCode.C;
                Debug.Log("texture changed to C");
                break;
            default:
                Debug.Log("Seharusnya ini gak di print");
                break;
        }
        //Set the Texture you assign in the Inspector as the main texture (Or Albedo)
        m_Renderer.material.SetTexture("_MainTex", m_MainTexture);
    }
}
