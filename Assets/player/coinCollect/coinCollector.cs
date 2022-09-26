using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollector : MonoBehaviour
{
    public GameObject player;
    public bool isDestroyed = false;
    public static List<bool> coinState = new List<bool>();
    int listPosition;

    void Awake()
    {
        coinState.Add(isDestroyed);
        listPosition = coinState.Count - 1;
        Debug.Log("The length is " +coinState.Count);
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
