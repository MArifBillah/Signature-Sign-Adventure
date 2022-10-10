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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
}
