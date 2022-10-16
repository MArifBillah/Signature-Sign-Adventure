using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class goalPortal : MonoBehaviour
{
    [Header("Public Variables")]
    public AudioSource correctSound;
    public AudioSource wrongSound;
    public GameObject player;
    public GameObject gun;
    public GameObject playerUI;
    public GameObject playerFreeCam;
    public GameObject playerCombatCam;
    public GameObject boosterCam;
    public GameObject MainCamera;
    public GameObject triggerBox;
    public GameObject playerObject;
    public GameObject glowPortal;

    public int chance;
    bool answer_1;
    bool answer_2;
    bool answer_3;
    [Header("For Slider Interface")]
    public float maxProcessTime;
    public Slider goalSlider;
    float goalProcessTime;
    public TextMeshProUGUI howManyChanceAreLeft;

    [Header("Goal point")]
    public GameObject spawnGoal;
    public Transform itemSpawnPoint;
    [Header("Ganti Texture ini")]
    Texture m_MainTexture;
    public Texture correct;
    public Texture defaultTexture;
    public Texture A;
    public Texture B;
    public Texture C;
    public Texture D;
    public Texture E;
    public Texture F;
    public Texture G;
    public Texture H;
    public Texture I;
    public Texture J;
    public Texture K;
    public Texture L;
    public Texture M;
    public Texture N;
    public Texture O;
    public Texture P;
    public Texture Q;
    public Texture R;
    public Texture S;
    public Texture T;
    public Texture U;
    public Texture V;
    public Texture W;
    public Texture X;
    public Texture Y;
    public Texture Z;

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
    
    [Header("For Hint Panel")]
    public GameObject hintPanel;
    public int hint;
    public bool isHinting;
    public bool isInGoal;
    
    void OnTriggerEnter(Collider other)
    {
        answer_1 = true;
        answer_2 = false;
        answer_3 = false;
        isInGoal = true;
        isHinting = false;
        if(other.tag == "Player")
        {
            player.GetComponent<playerMovement>().walkSound.Stop();
            player.GetComponent<playerMovement>().isAudioPlaying = false;
            playerUI.SetActive(false);
            gun.GetComponent<shootingGun>().enabled = false;
            //set the maximum value of the slider according to the given value
            goalSlider.maxValue = maxProcessTime;
            //set the intial value to 0 first
            goalSlider.value = 0f;
            goalProcessTime = 0f;

            //do the other stuffs
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

    void Start()
    {
        glowPortal.SetActive(false);
        isInGoal = false;
    }
    
    void Update()
    {
        howManyChanceAreLeft.text =chance.ToString();
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
                if(answerTime&& !Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.Tab) &&!isHinting)
                {
                    possiblyWrong = true;
                    if(Input.GetKey(KeyCode.Escape))
                    {
                        Debug.Log("You Can't close this one");
                    }
                    
                    if(Input.GetKey(answer[0]) && answer_1)
                    {
                        Debug.Log("jawaban 1 benar");
                        correctSound.Play();
                        changeThisTexture_1.GetComponent<Renderer>().material.SetTexture("_MainTex", correct);;
                        Input.ResetInputAxes();
                        answer_2 = true;
                        answer_1 = false; 
                        possiblyWrong = false;
                    }
                    else if (!Input.GetKey(answer[0]) && answer_1 && possiblyWrong)
                    {
                        chance--;
                        wrongSound.Play();
                        Input.ResetInputAxes();
                        Debug.Log("chance left = " +chance);
                    }
                    
                    if(Input.GetKey(answer[1]) && answer_2)
                    {
                        correctSound.Play();
                        Debug.Log("jawaban 2 benar, jawaban berikutnya adalah" + answer[2]);
                        changeThisTexture_2.GetComponent<Renderer>().material.SetTexture("_MainTex", correct);;
                        Input.ResetInputAxes();
                        possiblyWrong = false;
                        answer_3 = true;
                        answer_2 = false;
                    }
                    else if (!Input.GetKey(answer[1]) && answer_2 && possiblyWrong)
                    {
                        wrongSound.Play();
                        chance--;
                        Input.ResetInputAxes();
                        Debug.Log("chance left = " +chance);
                    }

                    if(Input.GetKey(answer[2]) && answer_3)
                    {
                        Debug.Log("Jawaban 3 Benar");
                        correctSound.Play();
                        changeThisTexture_3.GetComponent<Renderer>().material.SetTexture("_MainTex", correct);;
                        Input.ResetInputAxes();
                        answer_3 = false;
                        possiblyWrong = false;
                        triggerBox.GetComponent<BoxCollider>().enabled = false;
                        cancelGoal();
                        spawnGoalPoint();
                    }
                    else if (!Input.GetKey(answer[2]) && answer_3 && possiblyWrong)
                    {
                        wrongSound.Play();
                        chance--;
                        Input.ResetInputAxes();
                        Debug.Log("chance left = " +chance);
                    }
                }
                else if(answerTime && Input.GetKey(KeyCode.Tab) && !isHinting && chance >0)
                {
                    chance--;
                    isHinting = true;
                    StartCoroutine(waitHintCoroutine());
                }   
            }    
        }
        
        if(chance == 0)
        {
                playerObject.GetComponent<playerHealth>().PlayerDamage(30);
                chance += 3;
        }

        if(playerObject.GetComponent<playerHealth>().playerHP <= 0)
        {
            cancelGoal();
        }

        if(isInGoal)
        {
            showHint();
        }
    }

    //hint panel will show up for 5 seconds duration
    IEnumerator waitHintCoroutine()
    {
        // startSlider = true;
        // print("wait start");
        yield return new WaitForSecondsRealtime(5);
        // print("wait over");
        isHinting = false;
    }

    void showHint()
    {
        if(!isHinting)
        {
            hintPanel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }else
        {
            hintPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void FixedUpdate()
    {
        if(startSlider)
        {
            if(goalProcessTime <= maxProcessTime)
            {
                //add the value until the slider is full
                goalProcessTime += 0.02f;
                goalSlider.value = goalProcessTime;
            }
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
            randomNumber = Random.Range(1, 27);

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
                case 4:
                    Debug.Log("the i is = "+i);
                    m_MainTexture = D;
                    answer.Add(KeyCode.D);
                    Debug.Log("texture changed to D");
                    break;
                case 5:
                    m_MainTexture = E;
                    answer.Add(KeyCode.E);
                    Debug.Log("texture changed to E");
                    break;
                case 6:
                    m_MainTexture = F;
                    answer.Add(KeyCode.F);
                    Debug.Log("texture changed to F");
                    break;
                case 7:
                    m_MainTexture = G;
                    answer.Add(KeyCode.G);
                    Debug.Log("texture changed to G");
                    break;
                case 8:
                    m_MainTexture = H;
                    answer.Add(KeyCode.H);
                    Debug.Log("texture changed to H");
                    break;
                case 9:
                    m_MainTexture = I;
                    answer.Add(KeyCode.I);
                    Debug.Log("texture changed to I");
                    break;
                case 10:
                    m_MainTexture = J;
                    answer.Add(KeyCode.J);
                    Debug.Log("texture changed to J");
                    break;
                case 11:
                    m_MainTexture = K;
                    answer.Add(KeyCode.K);
                    Debug.Log("texture changed to K");
                    break;
                case 12:
                    m_MainTexture = L;
                    answer.Add(KeyCode.L);
                    Debug.Log("texture changed to L");
                    break;
                case 13:
                    m_MainTexture = M;
                    answer.Add(KeyCode.M);
                    Debug.Log("texture changed to M");
                    break;
                case 14:
                    m_MainTexture = N;
                    answer.Add(KeyCode.N);
                    Debug.Log("texture changed to N");
                    break;
                case 15:
                    m_MainTexture = O;
                    answer.Add(KeyCode.O);
                    Debug.Log("texture changed to O");
                    break;
                case 16:
                    m_MainTexture = P;
                    answer.Add(KeyCode.P);
                    Debug.Log("texture changed to P");
                    break;
                case 17:
                    m_MainTexture = Q;
                    answer.Add(KeyCode.Q);
                    Debug.Log("texture changed to Q");
                    break;
                case 18:
                    m_MainTexture = R;
                    answer.Add(KeyCode.R);
                    Debug.Log("texture changed to R");
                    break;
                case 19:
                    m_MainTexture = S;
                    answer.Add(KeyCode.S);
                    Debug.Log("texture changed to S");
                    break;
                case 20:
                    m_MainTexture = T;
                    answer.Add(KeyCode.T);
                    Debug.Log("texture changed to T");
                    break;
                case 21:
                    m_MainTexture = U;
                    answer.Add(KeyCode.U);
                    Debug.Log("texture changed to U");
                    break;
                case 22:
                    m_MainTexture = V;
                    answer.Add(KeyCode.V);
                    Debug.Log("texture changed to V");
                    break;
                case 23:
                    m_MainTexture = W;
                    answer.Add(KeyCode.W);
                    Debug.Log("texture changed to W");
                    break;
                case 24:
                    m_MainTexture = X;
                    answer.Add(KeyCode.X);
                    Debug.Log("texture changed to X");
                    break;
                case 25:
                    m_MainTexture = Y;
                    answer.Add(KeyCode.Y);
                    Debug.Log("texture changed to Y");
                    break;
                case 26:
                    m_MainTexture = Z;
                    answer.Add(KeyCode.Z);
                    Debug.Log("texture changed to Z");
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
        glowPortal.SetActive(true);
        Instantiate(spawnGoal,itemSpawnPoint.position,Quaternion.identity);
        Debug.Log("Goal point spawned");
    }

    public void cancelGoal()
    {
        // changeThisTexture.GetComponent<Renderer>().material.SetTexture("_MainTex", defaultTexture);
        gun.GetComponent<shootingGun>().enabled = true;
        playerUI.SetActive(true);
        startSlider = false;
        answerTime = false;
        isInGoal = false;
        choice = false;
        playerFreeCam.SetActive(true);
        boosterCam.SetActive(false);
        MainCamera.GetComponent<TPmove>().enabled = true;
        player.GetComponent<playerMovement>().enabled = true;
        
    }
}
