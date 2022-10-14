using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class coinCollector : MonoBehaviour
{
    public GameObject player;
    public bool isDestroyed = false;
    public static List<List<bool>> coinState = new List<List<bool>>();
    public AudioSource coinSound;
 
    int listPosition;
    public static int counter = 0;

    string coinName;

    int whichLevel;
    // public static bool goodToGo=false;

    void Awake()
    {
        if(coinState.Count < 4)
        {
            coinState.Clear();
            coinState.Add(new List<bool>());
            coinState.Add(new List<bool>());
            coinState.Add(new List<bool>());
            coinState.Add(new List<bool>());
        }
        
        string activeScene = SceneManager.GetActiveScene().name;
           
        if(activeScene == "level_1")
        {
            whichLevel = 0;
        }
        else if(activeScene == "level_2")
        {
            whichLevel = 1;
        }

        // Debug.Log("coinCollector is first");
        // if the player is not loading a progress then it will add the boolean variable to the list
        if(!saveAndLoad.isLoadingProgress)
        {
            Debug.Log("trying to define the coin in level = "+whichLevel);
                coinState[whichLevel].Add(isDestroyed);
            Debug.Log("isDestroyed is added");
                listPosition = coinState[whichLevel].Count - 1;
            Debug.Log("The Status is "+coinState[whichLevel][listPosition]);
            Debug.Log("The length is " +listPosition);
            saveAndLoad.isNewGame = false;
        }else{
            // but if the player is loading, then the list that was updated by load function should be able to be used with 'counter' as the new value for each coins positions in the list
            // Debug.Log("this is the number of the coin"+listPosition);
            // // new bug, out of range if loaded when player has won
            // // for this bug dont let the player to save in the wingame object, instead made them save on the next level
            // listPosition = counter;
            listPosition = counter;
            counter++;

            Debug.Log("this is the number of the coin"+listPosition);
            
            // Debug.Log("this is the state of the coin = "+coinState[100]);
            //  Debug.Log("The length of not new game is " +counter);
            // Debug.Log("The length is " +coinState[listPosition]);
        }
        
        // coinName = "coin"+counter.ToString();
        // counter++;
        // if(saveAndLoad.isNewGame)
        // {
        //     Debug.Log("Ini adalah game baru");
        //    isDestroyed = false;
        // }
        // else
        // {
        //     Debug.Log("ini bukan game baru");
        //      isDestroyed = PlayerPrefs.GetInt(coinName)==1?true:false;
        // }

    }
    void Update()
    {
        
        // Debug.Log("this number = "+listPosition+" is not out range"+coinState[listPosition]);
        // Debug.Log(coinState.Count);
        // Debug.Log(whichLevel);
        // Debug.Log(listPosition);
        isDestroyed = coinState[whichLevel][listPosition];
        //  Debug.Log("The length of coin in this level is "+coinState[whichLevel].Count);
        //  Debug.Log("The new game status is = "+saveAndLoad.isNewGame);
        destroyCoin();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isDestroyed = true;
            coinSound.Play();
            // PlayerPrefs.SetInt(coinName, isDestroyed?1:0);
            player.GetComponent<playerScore>().coinCollected++;
            coinState[whichLevel][listPosition] = isDestroyed;
            
        }
    }

    void destroyCoin()
    {
        // checkDestroy = PlayerPrefs.GetInt(coinName)==1?true:false;
        if(isDestroyed)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }else if(!isDestroyed){
            gameObject.GetComponent<BoxCollider>().enabled = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

    }
}
