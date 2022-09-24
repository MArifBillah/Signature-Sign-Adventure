using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerBoostMachine : MonoBehaviour
{
    [Header("Public Variables")]
    public GameObject player;
    public GameObject playerFreeCam;
    public GameObject playerCombatCam;
    public GameObject boosterCam;
    public GameObject triggerBox;
    public Slider boosterSlider;
    float BoosterProcessTime;
    public int chance;
    public float maxProcessTime;
    [Header("Booster Items")]
    public Transform itemSpawnPoint;
    public GameObject healthBooster;
    public GameObject attackSpeedBooster;
    GameObject spawnThisItem;
    [Header("Ganti Texture ini")]
    Texture m_MainTexture;
    public Texture defaultTexture;
    public Texture A;
    public Texture B;
    public Texture C;
    int randomNumber;
    int itemRandom;
    bool choice = false;
    KeyCode answer;
    bool answerTime = false;
    bool startSlider = false;
    
    Renderer m_Renderer;

    public GameObject changeThisTexture;
    
    // private Animator anim;
    void OnTriggerEnter(Collider other)
    {
        boosterSlider.maxValue = maxProcessTime;
        boosterSlider.value = 0f;
        BoosterProcessTime = 0f;
        if(other.tag == "Player")
        {
            changeTexture();
            randomBoosterItem();
            triggerBox.GetComponent<BoxCollider>().enabled = false;
            boosterCam.SetActive(true);
            playerCombatCam.SetActive(false);
            playerFreeCam.SetActive(false);

            GameObject.FindWithTag("Player").GetComponent<playerMovement>().enabled = false;
            GameObject.Find("Main Camera").GetComponent<TPmove>().enabled = false;
            // GameObject.Find("Main Camera").GetComponent<lookAtCam>().cheese(); //nanti diperbaiki lagi
            GameObject.Find("astroguy_running").GetComponent<Animator>().SetBool("isRunning", false);

        }
    }

    private void Update()
    {
        if(choice)
        {
            StartCoroutine(waitCoroutine());
            //using 'anykey' because the bottom 'else' will consume everything including no input and immediately close the booster as soon as player touch it
            if(Input.anyKey)
            {
                //using coroutine here so player has time to think, also the game might accidentally register the player movement as input if not given such delay lmao
                //need to make interface for the waiting time
                
                //this will only take answer after the coroutine return the true value for answerTime var
                if(answerTime)
                {
                    if(Input.GetKey(KeyCode.Escape))
                    {
                        choice = false;
                        cancelBooster();
                    }
                    else if(Input.GetKey(answer))
                    {
                        Debug.Log("jawaban benar");
                        //this will spawn the randomized booster item, see the randomItem function
                        Instantiate(spawnThisItem,itemSpawnPoint.position,Quaternion.identity);
                        cancelBooster();
                        choice = false;
                    }
                    else
                    {
                        Debug.Log("Jawaban Salah");
                        Debug.Log("Kesempatan tinggal "+chance);
                        chance--;
                        Input.ResetInputAxes();
                        if(chance == 0)
                        {
                            Debug.Log("Kesempatan Habis");
                            choice = false;
                            cancelBooster();
                        }
                    }
                }
            }   
        }

    }

    private void FixedUpdate()
    {
        if(startSlider)
        {
            if(BoosterProcessTime <= maxProcessTime)
            {
                BoosterProcessTime += 0.02f;
                boosterSlider.value = BoosterProcessTime;
            }
        }        
    }

    IEnumerator waitCoroutine()
    {
        startSlider = true;
        print("wait start");
        yield return new WaitForSecondsRealtime(maxProcessTime);
        print("wait over");
        answerTime = true;
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
                answer = KeyCode.A;
                Debug.Log("texture changed to A");
                break;
            case 2:
                m_MainTexture = B;
                answer = KeyCode.B;
                Debug.Log("texture changed to B");
                break;
            case 3:
                m_MainTexture = C;
                answer = KeyCode.C;
                Debug.Log("texture changed to C");
                break;
            default:
                Debug.Log("Seharusnya ini gak di print");
                break;
        }
        //Set the Texture you assign in the Inspector as the main texture (Or Albedo)
        m_Renderer.material.SetTexture("_MainTex", m_MainTexture);
    }

    private void randomBoosterItem()
    {
        itemRandom = Random.Range(1, 3);
        switch(itemRandom)
        {
            case 1:
                spawnThisItem = healthBooster;
                break;
            case 2:
                spawnThisItem = attackSpeedBooster;
                break;
            default:
                Debug.Log("Jangan diprint");
                break;
        }
    }
}
