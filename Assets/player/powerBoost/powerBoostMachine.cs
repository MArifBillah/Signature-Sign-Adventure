using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class powerBoostMachine : MonoBehaviour
{
    [Header("Public Variables")]
    public AudioSource correctSound;
    public AudioSource wrongSound;
    public GameObject gun;
    public GameObject player;
    public GameObject playerFreeCam;
    public GameObject playerCombatCam;
    public GameObject boosterCam;
    public GameObject triggerBox;
    public GameObject playerUI;
    public Slider boosterSlider;
    public TextMeshProUGUI howManyChanceAreLeft;
    public Transform teleport;
    float BoosterProcessTime;
    public int chance;
    public float maxProcessTime;

    [Header("Booster Items")]
    public Transform itemSpawnPoint;
    public GameObject healthBooster;
    public GameObject attackSpeedBooster;
    public GameObject shieldBooster;
    GameObject spawnThisItem;

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
    int itemRandom;
    public bool choice = false;
    KeyCode answer;
    bool answerTime = false;
    bool startSlider = false;
    
    Renderer m_Renderer;

    public GameObject changeThisTexture;
    public static bool isInMinigame;
    // public GameObject guide;

    [Header("For Hint Panel")]
    public GameObject hintPanel;
    public int hint;
    public bool isHinting;
    private bool isActive;

    void Start()
    {
        if(!isInMinigame)
        {
            isInMinigame = false;
        }

        isActive = false;


    }


    void OnTriggerEnter(Collider other)
    {
        

        if(other.tag == "Player")
        {
            isActive = true;
            isInMinigame = true;
            answerTime = false;
            isHinting = false;
            boosterSlider.maxValue = maxProcessTime;
            boosterSlider.value = 0f;
            BoosterProcessTime = 0f;
            player.GetComponent<playerMovement>().walkSound.Stop();
            player.GetComponent<playerMovement>().isAudioPlaying = false;
            
            // guide.SetActive(true);
            playerUI.SetActive(false);
            gun.GetComponent<shootingGun>().enabled = false;
            choice = true;
            answer = KeyCode.None;
            changeTexture();
            randomBoosterItem();
            
            boosterCam.SetActive(true);
            playerCombatCam.SetActive(false);
            playerFreeCam.SetActive(false);

            player.GetComponent<playerMovement>().enabled = false;
            GameObject.Find("Main Camera").GetComponent<TPmove>().enabled = false;
            // GameObject.Find("Main Camera").GetComponent<lookAtCam>().cheese(); //nanti diperbaiki lagi
            GameObject.Find("astroguy_running").GetComponent<Animator>().SetBool("isRunning", false);

        }
    }

    private void Update()
    {
        if(isInMinigame && isActive)
        {
            m_Renderer.material.SetTexture("_MainTex", m_MainTexture);
        }

        howManyChanceAreLeft.text =chance.ToString();   
        if(choice && chance>0)
        {     
            StartCoroutine(waitCoroutine());
            //using 'anykey' because the bottom 'else' will consume everything including no input and immediately close the booster as soon as player touch it
            if(Input.anyKey)
            {
                //using coroutine here so player has time to think, also the game might accidentally register the player movement as input if not given such delay lmao
                //need to make interface for the waiting time
                
                //this will only take answer after the coroutine return the true value for answerTime var
                //(BoosterProcessTime > maxProcessTime) the final value of BoosterProcesTime is actually slightly bigger than maxProcessTime, this doesn't really shows in the game itself but I have to make the condition using > in order to make it works
            
                if(answerTime && (BoosterProcessTime > maxProcessTime) && !Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.Tab) &&!isHinting)
                {
                    if(Input.GetKey(KeyCode.Space)) 
                    {
                        
                        cancelBooster();
                        player.transform.position = teleport.position;
                    }
                    else if(Input.GetKey(answer))
                    {
                        // Debug.Log("jawaban benar");
                        correctSound.Play();
                        //this will spawn the randomized booster item, see the randomItem function
                        Instantiate(spawnThisItem,itemSpawnPoint.position,Quaternion.identity);
                        changeThisTexture.GetComponent<Renderer>().material.SetTexture("_MainTex", correct);
                        triggerBox.GetComponent<BoxCollider>().enabled = false;
                        cancelBooster();
                        choice = false;
                    }
                    else
                    {
                        // Debug.Log("Jawaban Salah");
                        wrongSound.Play();
                        // Debug.Log("Kesempatan tinggal "+chance);
                        chance--;
                        Input.ResetInputAxes();
                        if(chance == 0)
                        {
                            // Debug.Log("Kesempatan Habis");
                            choice = false;
                            cancelBooster();
                        }
                    }
                }
                else if(answerTime && (BoosterProcessTime > maxProcessTime) && Input.GetKey(KeyCode.Tab) && !isHinting && chance >1)
                {
                    chance--;
                    isHinting = true;
                    StartCoroutine(waitHintCoroutine());
                    
                }
            }   
        }
        else if(chance <1)
        {
            // Debug.Log("Chance Habis");
            cancelBooster();
        }
    // Debug.Log(isInMinigame);
    if(isInMinigame && isActive)
    {
        // // Debug.Log(isHinting);
        showHint();
    }
        

    }

    void showHint()
    {
        if(!isHinting)
        {
            // Debug.Log("this doesnt work");
            hintPanel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }else
        {
            // Debug.Log("this work work");
            hintPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
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
        // print("wait start");
        yield return new WaitForSecondsRealtime(maxProcessTime);
        // print("wait over");
        answerTime = true;
    }


    IEnumerator waitHintCoroutine()
    {
        // startSlider = true;
        // print("wait start");
        yield return new WaitForSecondsRealtime(5);
        // print("wait over");
        isHinting = false;
    }

    public void cancelBooster()
    {
        //IF iSInMinigame you can't pause the game
        if(isHinting)
        {
            isHinting = false;
        }
        // Debug.Log("why am i being printed");
        
        isActive = false;
        playerUI.SetActive(true);
        startSlider = false;
        choice = false;
        isInMinigame = false;
        answerTime = false;
        changeThisTexture.GetComponent<Renderer>().material.SetTexture("_MainTex", defaultTexture);
        playerFreeCam.SetActive(true);
        boosterCam.SetActive(false);
        GameObject.Find("Main Camera").GetComponent<TPmove>().enabled = true;
        player.GetComponent<playerMovement>().enabled = true;
        gun.GetComponent<shootingGun>().enabled = true;
        // gameObject.GetComponent<powerBoostMachine>().enabled = false;
        
    }


    public void changeTexture()
    {
        // // Debug.Log("texture changed");
        randomNumber = 0;
        randomNumber = Random.Range(1, 27);
        //Fetch the Renderer from the GameObject
        m_Renderer = changeThisTexture.GetComponent<Renderer> ();
        Debug.Log("nomor randomnya adalah ="+randomNumber);
        switch (randomNumber)
        {
            case 1:
                m_MainTexture = A;
                answer = KeyCode.A;
                m_Renderer.material.SetTexture("_MainTex", A);
                Debug.Log("texture changed to A");
                break;
            case 2:
                m_MainTexture = B;
                answer = KeyCode.B;
                m_Renderer.material.SetTexture("_MainTex", B);
                Debug.Log("texture changed to B");
                break;
            case 3:
                m_MainTexture = C;
                answer = KeyCode.C;
                m_Renderer.material.SetTexture("_MainTex", C);
                Debug.Log("texture changed to C");
                break;
            case 4:
                m_MainTexture = D;
                answer = KeyCode.D;
                m_Renderer.material.SetTexture("_MainTex", D);
                Debug.Log("texture changed to D");
                break;
            case 5:
                m_MainTexture = E;
                answer = KeyCode.E;
                m_Renderer.material.SetTexture("_MainTex", E);
                Debug.Log("texture changed to E");
                break;
            case 6:
                m_MainTexture = F;
                answer = KeyCode.F;
                m_Renderer.material.SetTexture("_MainTex", F);
                Debug.Log("texture changed to F");
                break;
            case 7:
                m_MainTexture = G;
                answer = KeyCode.G;
                m_Renderer.material.SetTexture("_MainTex", G);
                Debug.Log("texture changed to G");
                break;
            case 8:
                m_MainTexture = H;
                answer = KeyCode.H;
                m_Renderer.material.SetTexture("_MainTex", H);
                Debug.Log("texture changed to H");
                break;
            case 9:
                m_MainTexture = I;
                answer = KeyCode.I;
                m_Renderer.material.SetTexture("_MainTex", I);
                Debug.Log("texture changed to I");
                break;
            case 10:
                m_MainTexture = J;
                answer = KeyCode.J;
                m_Renderer.material.SetTexture("_MainTex", J);
                Debug.Log("texture changed to J");
                break;
            case 11:
                m_MainTexture = K;
                answer = KeyCode.K;
                m_Renderer.material.SetTexture("_MainTex", K);
                Debug.Log("texture changed to K");
                break;
            case 12:
                m_MainTexture = L;
                answer = KeyCode.L;
                m_Renderer.material.SetTexture("_MainTex", L);
                Debug.Log("texture changed to L");
                break;
            case 13:
                m_MainTexture = M;
                answer = KeyCode.M;
                m_Renderer.material.SetTexture("_MainTex", M);
                Debug.Log("texture changed to M");
                break;
            case 14:
                m_MainTexture = N;
                answer = KeyCode.N;
                m_Renderer.material.SetTexture("_MainTex", N);
                Debug.Log("texture changed to N");
                break;
            case 15:
                m_MainTexture = O;
                answer = KeyCode.O;
                m_Renderer.material.SetTexture("_MainTex", O);
                Debug.Log("texture changed to O");
                break;
            case 16:
                m_MainTexture = P;
                answer = KeyCode.P;
                m_Renderer.material.SetTexture("_MainTex", P);
                Debug.Log("texture changed to P");
                break;
            case 17:
                m_MainTexture = Q;
                answer = KeyCode.Q;
                m_Renderer.material.SetTexture("_MainTex", Q);
                Debug.Log("texture changed to Q");
                break;
            case 18:
                m_MainTexture = R;
                answer = KeyCode.R;
                m_Renderer.material.SetTexture("_MainTex", R);
                Debug.Log("texture changed to R");
                break;
            case 19:
                m_MainTexture = S;
                answer = KeyCode.S;
                m_Renderer.material.SetTexture("_MainTex", S);
                Debug.Log("texture changed to S");
                break;
            case 20:
                m_MainTexture = T;
                answer = KeyCode.T;
                m_Renderer.material.SetTexture("_MainTex", T);
                Debug.Log("texture changed to T");
                break;
            case 21:
                m_MainTexture = U;
                answer = KeyCode.U;
                m_Renderer.material.SetTexture("_MainTex", U);
                Debug.Log("texture changed to U");
                break;
            case 22:
                m_MainTexture = V;
                answer = KeyCode.V;
                m_Renderer.material.SetTexture("_MainTex", V);
                Debug.Log("texture changed to V");
                break;
            case 23:
                m_MainTexture = W;
                answer = KeyCode.W;
                m_Renderer.material.SetTexture("_MainTex", W);
                Debug.Log("texture changed to W");
                break;
            case 24:
                m_MainTexture = X;
                answer = KeyCode.X;
                m_Renderer.material.SetTexture("_MainTex", X);
                Debug.Log("texture changed to X");
                break;
            case 25:
                m_MainTexture = Y;
                answer = KeyCode.Y;
                m_Renderer.material.SetTexture("_MainTex", Y);
                Debug.Log("texture changed to Y");
                break;
            case 26:
                
                answer = KeyCode.Z;
                Debug.Log("texture changed to Z");
                m_Renderer.material.SetTexture("_MainTex", Z);
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
        // Debug.Log("Item randomized");
        itemRandom = Random.Range(1, 4);
        switch(itemRandom)
        {
            case 1:
                spawnThisItem = healthBooster;
                break;
            case 2:
                spawnThisItem = attackSpeedBooster;
                break;
            case 3:
                spawnThisItem = shieldBooster;
                break;
            default:
                // Debug.Log("Jangan diprint");
                break;
        }
    }
}
