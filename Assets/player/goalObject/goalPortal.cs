using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goalPortal : MonoBehaviour
{
    [Header("Public Variables")]
    public GameObject player;
    public GameObject playerFreeCam;
    public GameObject playerCombatCam;
    public GameObject boosterCam;
    public GameObject MainCamera;
    public GameObject triggerBox;
    public GameObject playerObject;
    // public Slider boosterSlider;
    float BoosterProcessTime;
    public int chance;
    bool answer_1;
    bool answer_2;
    bool answer_3;
    public float maxProcessTime;
    [Header("Goal point")]
    public GameObject spawnGoal;
    public Transform itemSpawnPoint;
    [Header("Ganti Texture ini")]
    Texture m_MainTexture;
    public Texture defaultTexture;
    public Texture A;
    public Texture B;
    public Texture C;

    int randomNumber;
    Renderer m_Renderer;
    int itemRandom;
    bool choice = false;
    bool possiblyWrong = true;
    List<KeyCode> answer = new List<KeyCode>();
    bool answerTime = false;
    bool startSlider = false;

    public GameObject changeThisTexture_1;
    public GameObject changeThisTexture_2;
    public GameObject changeThisTexture_3;
    GameObject changeTextures;
    
    // private Animator anim;
    void OnTriggerEnter(Collider other)
    {
        answer_1 = true;
        answer_2 = false;
        answer_3 = false;
        // boosterSlider.maxValue = maxProcessTime;
        // boosterSlider.value = 0f;
        // BoosterProcessTime = 0f;
        if(other.tag == "Player")
        {
            boosterCam.SetActive(true);
            Debug.Log("Process Should start here");  
            playerCombatCam.SetActive(false);
            playerFreeCam.SetActive(false);
            changeTexture(); 
            player.GetComponent<playerMovement>().enabled = false;
            MainCamera.GetComponent<TPmove>().enabled = false;
            GameObject.Find("astroguy_running").GetComponent<Animator>().SetBool("isRunning", false);

        }
    }

    
    void Update()
    {
        if(choice && chance>0)
        {
            StartCoroutine(waitCoroutine());
                    // print("wait over");
            //using 'anykey' because the bottom 'else' will consume everything including no input and immediately close the booster as soon as player touch it
            if(Input.anyKey)
            {
                //using coroutine here so player has time to think, also the game might accidentally register the player movement as input if not given such delay lmao
                //need to make interface for the waiting time
                
                //this will only take answer after the coroutine return the true value for answerTime var
                if(answerTime)
                {
                    possiblyWrong = true;
                    if(Input.GetKey(KeyCode.Escape))
                    {
                        Debug.Log("You Can't close this one");
                    }
                    
                    if(Input.GetKey(answer[0]) && answer_1)
                    {
                        Debug.Log("jawaban 1 benar");
                        Input.ResetInputAxes();
                        answer_2 = true;
                        answer_1 = false; 
                        possiblyWrong = false;
                    }
                    else if (!Input.GetKey(answer[0]) && answer_1 && possiblyWrong)
                    {
                        chance--;
                        Input.ResetInputAxes();
                        Debug.Log("chance left = " +chance);
                    }
                    
                    if(Input.GetKey(answer[1]) && answer_2)
                    {

                        Debug.Log("jawaban 2 benar, jawaban berikutnya adalah" + answer[2]);
                        Input.ResetInputAxes();
                        possiblyWrong = false;
                        answer_3 = true;
                        answer_2 = false;
                    }
                    else if (!Input.GetKey(answer[1]) && answer_2 && possiblyWrong)
                    {
                        chance--;
                        Input.ResetInputAxes();
                        Debug.Log("chance left = " +chance);
                    }

                    if(Input.GetKey(answer[2]) && answer_3)
                    {
                        Debug.Log("Jawaban 3 Benar");
                        Input.ResetInputAxes();
                        answer_3 = false;
                        possiblyWrong = false;
                        triggerBox.GetComponent<BoxCollider>().enabled = false;
                        cancelGoal();
                        spawnGoalPoint();
                    }
                    else if (!Input.GetKey(answer[2]) && answer_3 && possiblyWrong)
                    {
                        chance--;
                        Input.ResetInputAxes();
                        Debug.Log("chance left = " +chance);
                    }
                }
            }

           
        }
        
        if(chance == 0)
        {
            playerObject.GetComponent<playerHealth>().PlayerDamage(30);
            chance += 3;
        }
    }

    IEnumerator waitCoroutine()
    {
        startSlider = true;
        // print("wait start");
        yield return new WaitForSecondsRealtime(maxProcessTime);
        answerTime = true;
    }

    public void changeTexture()
    {
        choice = true;
        for(int i=0; i<3 ; i++)
        {
            int flag = i+1;
            switch(flag)
            {
                case 1:
                    changeTextures = changeThisTexture_1;
                    Debug.Log("Texture Changed to texture 1");
                    break;
                case 2:
                    changeTextures = changeThisTexture_2;
                    break;
                case 3:
                    changeTextures = changeThisTexture_3;
                    break;
                default:
                    Debug.Log("seharusnya tidak ada");
                    break;
            }
            randomNumber = Random.Range(1, 4);

            //Fetch the Renderer from the GameObject
            m_Renderer = changeTextures.GetComponent<Renderer>();
            Debug.Log("nomor randomnya adalah ="+randomNumber);
            switch (randomNumber)
            {
                case 1:
                    Debug.Log("the i is = "+i);
                    m_MainTexture = A;
                    answer.Add(KeyCode.A);
                    Debug.Log("texture changed to A");
                    break;
                case 2:
                    Debug.Log("the i is = "+i);
                    m_MainTexture = B;
                    answer.Add(KeyCode.B);
                    Debug.Log("texture changed to B");
                    break;
                case 3:
                    Debug.Log("the i is = "+i);
                    m_MainTexture = C;
                    answer.Add(KeyCode.C);
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
    
    void spawnGoalPoint()
    {
        Instantiate(spawnGoal,itemSpawnPoint.position,Quaternion.identity);
        Debug.Log("Goal point spawned");
    }

    public void cancelGoal()
    {
        // changeThisTexture.GetComponent<Renderer>().material.SetTexture("_MainTex", defaultTexture);
        playerFreeCam.SetActive(true);
        boosterCam.SetActive(false);
        MainCamera.GetComponent<TPmove>().enabled = true;
        player.GetComponent<playerMovement>().enabled = true;
        
    }
}
