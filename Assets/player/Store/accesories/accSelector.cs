using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accSelector : MonoBehaviour
{
    public GameObject item_1;
    public GameObject item_2;

    public static bool item1 = false;
    public static bool item2 = false;

    public static bool unlockItem1;
    public static bool unlockItem2;
    
    

    void Start()
    {
        
        changeItem();
        unlockItem1 = PlayerPrefs.GetInt("unlockItem1")==1?true:false;
        Debug.Log(unlockItem1);
        unlockItem2 = PlayerPrefs.GetInt("unlockItem2")==1?true:false;
    }

    void Update()
    {
        // Debug.Log(unlockItem1);
    }

    public void changeItem()
    {
        Debug.Log("testing");
        if(item1)
        {
            item_1.SetActive(true);
            item_2.SetActive(false);
        }

        if(item2)
        {
            item_1.SetActive(false);
            item_2.SetActive(true);
        }

        PlayerPrefs.SetInt("unlockItem1",1);
    }

    public void equipItem_1()
    {
        Debug.Log(unlockItem1);
        if(unlockItem1)
        {
            Debug.Log("testing equipitem1");
            item1 = true;
            item2 = false;
            changeItem();
        }
    }

    public void equipItem_2()
    {
        Debug.Log(unlockItem2);
        if(unlockItem2)
        {
            item1 = false;
            item2 = true;
            changeItem();
        }
        else if(!unlockItem2 && PlayerPrefs.GetInt("currencyStored") >= 3)
        {
            int subsCoins = PlayerPrefs.GetInt("currencyStored") - 3;
            PlayerPrefs.SetInt("currencyStored", subsCoins);
            unlockItem2 =true;
            PlayerPrefs.SetInt("unlockItem2",unlockItem2?1:0);
            item1 = false;
            item2 = true;
            changeItem();
        }
        else
        {
            Debug.Log("Uangnya tidak cukup bos!");
        }
    }
}
