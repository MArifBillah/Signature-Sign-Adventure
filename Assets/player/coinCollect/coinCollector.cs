using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollector : MonoBehaviour
{
    public GameObject player;
    public bool isDestroyed = false;
    // public static List<bool> coinState = new List<bool>();
 
    // int listPosition;
    public static int counter = 0;

    string coinName;
    // public static bool goodToGo=false;

    void Awake()
    {
        // Debug.Log("coinCollector is first");
        //if the player is not loading a progress then it will add the boolean variable to the list
        // if(!saveAndLoad.isLoadingProgress)
        // {
        //     // Debug.Log("this is a loading progress");

        //     coinState.Add(isDestroyed);
        //     listPosition = coinState.Count - 1;
        //     Debug.Log("The length is " +coinState.Count);
        // }else{
            //but if the player is loading, then the list that was updated by load function should be able to be used with 'counter' as the new value for each coins positions in the list
            // Debug.Log("this is not a loading progress");
            // new bug, out of range if loaded when player has won
            //for this bug dont let the player to save in the wingame object, instead made them save on the next level
            // listPosition = counter;
            // counter++;
            //  Debug.Log("The length of not new game is " +counter);
            // if(counter == coinState.Count)
            // {
            //     counter = 0;
            // }
        // }
        
        coinName = "coin"+counter.ToString();
        counter++;
        if(saveAndLoad.isNewGame)
        {
           isDestroyed = false;
        }
        else
        {
             isDestroyed = PlayerPrefs.GetInt(coinName)==1?true:false;
        }
        

    }
    void Update()
    {
        destroyCoin();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isDestroyed = true;
            PlayerPrefs.SetInt(coinName, isDestroyed?1:0);
            player.GetComponent<playerScore>().coinCollected++;
            // coinState[listPosition] = true;
            
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
