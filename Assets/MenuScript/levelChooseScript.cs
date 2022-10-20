using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelChooseScript : MonoBehaviour
{
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;
    public GameObject level5;
    public bool startWait;
    // Start is called before the first frame update
    void Start()
    {
        startWait = true;
    }
    void check()
    {
        // Debug.Log("Hello script is starting"+ menuController.level_1);
        if(menuController.level_1)
        {
            level1.SetActive(false);
        }
        else if(!menuController.level_1)
        {
            level1.SetActive(true);
        }
    
        if(menuController.level_2)
        {
            level2.SetActive(false);
        }
        else if(!menuController.level_2)
        {
            level2.SetActive(true);
        }

        if(menuController.level_3)
        {
            level3.SetActive(false);
        }
        else if(!menuController.level_3)
        {
            level3.SetActive(true);
        }

        if(menuController.level_4)
        {
            level4.SetActive(false);
        }
        else if(!menuController.level_4)
        {
            level4.SetActive(true);
        }

        if(menuController.level_5)
        {
            level5.SetActive(false);
        }
        else if(!menuController.level_5)
        {
            level5.SetActive(true);
        }  
    }
    
    // Update is called once per frame
    void Update()
    {
    // Debug.Log("Hello script is starting"+ menuController.level_1);
    if(startWait)
    {
        check();
        StartCoroutine(waitCoroutine());
        startWait = false;
    }

     
    }

    IEnumerator waitCoroutine()
    {
        
        yield return new WaitForSecondsRealtime(5);
        startWait = false;
    }
}
