using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class powerBoostMachine : MonoBehaviour
{
    [Header("Public Variables")]
    public GameObject player;
    public GameObject playerFreeCam;
    public GameObject playerCombatCam;
    public GameObject boosterCam;
    public GameObject triggerBox;
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
    public static bool isInMinigame = false;
    public GameObject guide;


    void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("when player enter its " +choice);
        isInMinigame = true;
        answerTime = false;
        boosterSlider.maxValue = maxProcessTime;
        boosterSlider.value = 0f;
        BoosterProcessTime = 0f;
        if(other.tag == "Player")
        {
            guide.SetActive(true);
            choice = true;
            answer = KeyCode.None;
            changeTexture();
            randomBoosterItem();
            Debug.Log("then its "+choice);
            
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
            
                if(answerTime && (BoosterProcessTime > maxProcessTime))
                {
                    if(Input.GetKey(KeyCode.Space)) 
                    {
                        
                        cancelBooster();
                        player.transform.position = teleport.position;
                    }
                    else if(Input.GetKey(answer))
                    {
                        Debug.Log("jawaban benar");
                        //this will spawn the randomized booster item, see the randomItem function
                        Instantiate(spawnThisItem,itemSpawnPoint.position,Quaternion.identity);
                        triggerBox.GetComponent<BoxCollider>().enabled = false;
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
        else if(chance <1)
        {
            Debug.Log("Chance Habis");
            cancelBooster();
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

    public void cancelBooster()
    {
        //IF iSInMinigame you can't pause the game
        startSlider = false;
        choice = false;
        isInMinigame = false;
        answerTime = false;
        changeThisTexture.GetComponent<Renderer>().material.SetTexture("_MainTex", defaultTexture);
        playerFreeCam.SetActive(true);
        boosterCam.SetActive(false);
        GameObject.Find("Main Camera").GetComponent<TPmove>().enabled = true;
        GameObject.FindWithTag("Player").GetComponent<playerMovement>().enabled = true;
        // gameObject.GetComponent<powerBoostMachine>().enabled = false;
        
    }


    public void changeTexture()
    {
        Debug.Log("texture changed");
        
        randomNumber = Random.Range(1, 26);
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
            case 4:
                m_MainTexture = D;
                answer = KeyCode.D;
                Debug.Log("texture changed to D");
                break;
            case 5:
                m_MainTexture = E;
                answer = KeyCode.E;
                Debug.Log("texture changed to E");
                break;
            case 6:
                m_MainTexture = F;
                answer = KeyCode.F;
                Debug.Log("texture changed to F");
                break;
            case 7:
                m_MainTexture = G;
                answer = KeyCode.G;
                Debug.Log("texture changed to G");
                break;
            case 8:
                m_MainTexture = H;
                answer = KeyCode.H;
                Debug.Log("texture changed to H");
                break;
            case 9:
                m_MainTexture = I;
                answer = KeyCode.I;
                Debug.Log("texture changed to I");
                break;
            case 10:
                m_MainTexture = J;
                answer = KeyCode.J;
                Debug.Log("texture changed to J");
                break;
            case 11:
                m_MainTexture = K;
                answer = KeyCode.K;
                Debug.Log("texture changed to K");
                break;
            case 12:
                m_MainTexture = L;
                answer = KeyCode.L;
                Debug.Log("texture changed to L");
                break;
            case 13:
                m_MainTexture = M;
                answer = KeyCode.M;
                Debug.Log("texture changed to M");
                break;
            case 14:
                m_MainTexture = N;
                answer = KeyCode.N;
                Debug.Log("texture changed to N");
                break;
            case 15:
                m_MainTexture = O;
                answer = KeyCode.O;
                Debug.Log("texture changed to O");
                break;
            case 16:
                m_MainTexture = P;
                answer = KeyCode.P;
                Debug.Log("texture changed to P");
                break;
            case 17:
                m_MainTexture = Q;
                answer = KeyCode.Q;
                Debug.Log("texture changed to Q");
                break;
            case 18:
                m_MainTexture = R;
                answer = KeyCode.R;
                Debug.Log("texture changed to R");
                break;
            case 19:
                m_MainTexture = S;
                answer = KeyCode.S;
                Debug.Log("texture changed to S");
                break;
            case 20:
                m_MainTexture = T;
                answer = KeyCode.T;
                Debug.Log("texture changed to T");
                break;
            case 21:
                m_MainTexture = U;
                answer = KeyCode.U;
                Debug.Log("texture changed to U");
                break;
            case 22:
                m_MainTexture = V;
                answer = KeyCode.V;
                Debug.Log("texture changed to V");
                break;
            case 23:
                m_MainTexture = W;
                answer = KeyCode.W;
                Debug.Log("texture changed to W");
                break;
            case 24:
                m_MainTexture = X;
                answer = KeyCode.X;
                Debug.Log("texture changed to X");
                break;
            case 25:
                m_MainTexture = Y;
                answer = KeyCode.Y;
                Debug.Log("texture changed to Y");
                break;
            case 26:
                m_MainTexture = Z;
                answer = KeyCode.Z;
                Debug.Log("texture changed to Z");
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
        Debug.Log("Item randomized");
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
                Debug.Log("Jangan diprint");
                break;
        }
    }
}
