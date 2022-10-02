using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollector : MonoBehaviour
{
    public GameObject player;
    public bool isDestroyed = false;
    public static List<bool> coinState = new List<bool>();
 
    int listPosition;
    public static int counter = 0;
    // public static bool goodToGo=false;

    void Start()
    {
        // Debug.Log("coinCollector is first");
        //if the player is not loading a progress then it will add the boolean variable to the list
        if(!saveAndLoad.isLoadingProgress)
        {
            // Debug.Log("this is a loading progress");

            coinState.Add(isDestroyed);
            listPosition = coinState.Count - 1;
            Debug.Log("The length is " +coinState.Count);
        }else{
            //but if the player is loading, then the list that was updated by load function should be able to be used with 'counter' as the new value for each coins positions in the list
            // Debug.Log("this is not a loading progress");
            // new bug, out of range if loaded when player has won
            //for this bug dont let the player to save in the wingame object, instead made them save on the next level
            listPosition = counter;
            counter++;
             Debug.Log("The length is " +counter);
            if(counter == coinState.Count)
            {
                counter = 0;
            }
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
            player.GetComponent<playerScore>().coinCollected++;
            coinState[listPosition] = true;
            
        }
    }

    void destroyCoin()
    {
        if(coinState[listPosition])
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }else if(!coinState[listPosition]){
            gameObject.GetComponent<BoxCollider>().enabled = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

    }
}
