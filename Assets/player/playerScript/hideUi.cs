using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideUi : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hintUI;
    public bool isHide;

    void Start()
    {
        isHide = false;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            if(!isHide && !powerBoostMachine.isInMinigame)
            {
                isHide = true;
                hintUI.SetActive(false);
                
            }
            else if(isHide && !powerBoostMachine.isInMinigame)
            {
                isHide = false;
                hintUI.SetActive(true);
                
            }
        }

    }
}
