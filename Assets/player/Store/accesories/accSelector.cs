using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accSelector : MonoBehaviour
{
    public GameObject item_1;
    public GameObject item_2;
    public GameObject item_3;
    public GameObject item_4;
    public GameObject item_5;
    public GameObject item_6;
    public GameObject item_7;
    // public GameObject item_2;

    public static bool item1 = false;
    public static bool item2 = false;
    public static bool item3 = false;
    public static bool item4 = false;
    public static bool item5 = false;
    public static bool item6 = false;
    public static bool item7 = false;


    public static bool unlockItem1;
    public static bool unlockItem2;
    public static bool unlockItem3;
    public static bool unlockItem4;
    public static bool unlockItem5;
    public static bool unlockItem6;
    public static bool unlockItem7;

    
    

    void Start()
    {
        
        item1 = PlayerPrefs.GetInt("Item1")==1?true:false;
        item2 = PlayerPrefs.GetInt("Item2")==1?true:false;
        item3 = PlayerPrefs.GetInt("Item3")==1?true:false;
        item4 = PlayerPrefs.GetInt("Item4")==1?true:false;
        item5 = PlayerPrefs.GetInt("Item5")==1?true:false;
        item6 = PlayerPrefs.GetInt("Item6")==1?true:false;
        item7 = PlayerPrefs.GetInt("Item7")==1?true:false;
        changeItem();
        unlockItem1 = PlayerPrefs.GetInt("unlockItem1")==1?true:false;
        unlockItem2 = PlayerPrefs.GetInt("unlockItem2")==1?true:false;
        unlockItem3 = PlayerPrefs.GetInt("unlockItem3")==1?true:false;
        unlockItem4 = PlayerPrefs.GetInt("unlockItem4")==1?true:false;
        unlockItem5 = PlayerPrefs.GetInt("unlockItem5")==1?true:false;
        unlockItem6 = PlayerPrefs.GetInt("unlockItem6")==1?true:false;
        unlockItem7 = PlayerPrefs.GetInt("unlockItem7")==1?true:false;
    }

    void Update()
    {
        // Debug.Log(unlockItem1);
    }

    public void resetItem()
    {
        item_1.SetActive(false);
        item_2.SetActive(false);
        item_3.SetActive(false);
        item_4.SetActive(false);
        item_5.SetActive(false);
        item_6.SetActive(false);
        item_7.SetActive(false);
    }

    public void resetItemStatus()
    {
        item1 = false;
        item2 = false;
        item3 = false;
        item4 = false;
        item5 = false;
        item6 = false;
        item7 = false;
    }
    public void changeItem()
    {
        resetItem();
        if(item1)
        {
            item_1.SetActive(true);
        }

        if(item2)
        {
            item_2.SetActive(true);
        }

        if(item3)
        {
            item_3.SetActive(true);
        }

        if(item4)
        {
            item_4.SetActive(true);
        }

        if(item5)
        {
            item_5.SetActive(true);
        }

        if(item6)
        {
            item_6.SetActive(true);
        }

        if(item7)
        {
            item_7.SetActive(true);
        }

        PlayerPrefs.SetInt("unlockItem1",1);
        PlayerPrefs.SetInt("Item1",item1?1:0);
        PlayerPrefs.SetInt("Item2",item2?1:0);
        PlayerPrefs.SetInt("Item3",item3?1:0);
        PlayerPrefs.SetInt("Item4",item4?1:0);
        PlayerPrefs.SetInt("Item5",item5?1:0);
        PlayerPrefs.SetInt("Item6",item6?1:0);
        PlayerPrefs.SetInt("Item7",item7?1:0);        
    }

    public void equipItem_1()
    {
        Debug.Log("equipment 1 adalah "+unlockItem1);
        if(unlockItem1)
        {
            Debug.Log("testing equipitem1");
            resetItemStatus();
            item1 = true;
            changeItem();
        }
    }

    public void equipItem_2()
    {
        Debug.Log(unlockItem2);
        if(unlockItem2)
        {
            resetItemStatus();
            item2 = true;
            changeItem();
        }
        else if(!unlockItem2 && PlayerPrefs.GetInt("currencyStored") >= 3)
        {
            int subsCoins = PlayerPrefs.GetInt("currencyStored") - 3;
            PlayerPrefs.SetInt("currencyStored", subsCoins);
            unlockItem2 =true;
            PlayerPrefs.SetInt("unlockItem2",unlockItem2?1:0);
            resetItemStatus();
            item2 = true;
            changeItem();
        }
        else
        {
            Debug.Log("Uangnya tidak cukup bos!");
        }
    }

    public void equipItem_3()
    {
        Debug.Log("item 3 is "+unlockItem3);
        if(unlockItem3)
        {
            resetItemStatus();
            item3 = true;
            changeItem();
        }
        else if(!unlockItem3 && PlayerPrefs.GetInt("currencyStored") >= 3)
        {
            int subsCoins = PlayerPrefs.GetInt("currencyStored") - 3;
            PlayerPrefs.SetInt("currencyStored", subsCoins);
            unlockItem3 =true;
            PlayerPrefs.SetInt("unlockItem3",unlockItem3?1:0);
            resetItemStatus();
            item3 = true;
            changeItem();
        }
        else
        {
            Debug.Log("Uangnya tidak cukup bos!");
        }
    }

    public void equipItem_4()
    {
        Debug.Log("item 4 is "+unlockItem4);
        if(unlockItem4)
        {
            resetItemStatus();
            item4 = true;
            changeItem();
        }
        else if(!unlockItem4 && PlayerPrefs.GetInt("currencyStored") >= 3)
        {
            int subsCoins = PlayerPrefs.GetInt("currencyStored") - 3;
            PlayerPrefs.SetInt("currencyStored", subsCoins);
            unlockItem4 =true;
            PlayerPrefs.SetInt("unlockItem4",unlockItem4?1:0);
            resetItemStatus();
            item4 = true;
            changeItem();
        }
        else
        {
            Debug.Log("Uangnya tidak cukup bos!");
        }
    }

    public void equipItem_5()
    {
        Debug.Log("item 5 is "+unlockItem5);
        if(unlockItem5)
        {
            resetItemStatus();
            item5 = true;
            changeItem();
        }
        else if(!unlockItem5 && PlayerPrefs.GetInt("currencyStored") >= 3)
        {
            int subsCoins = PlayerPrefs.GetInt("currencyStored") - 3;
            PlayerPrefs.SetInt("currencyStored", subsCoins);
            unlockItem5 =true;
            PlayerPrefs.SetInt("unlockItem5",unlockItem5?1:0);
            resetItemStatus();
            item5 = true;
            changeItem();
        }
        else
        {
            Debug.Log("Uangnya tidak cukup bos!");
        }
    }

    public void equipItem_6()
    {
        Debug.Log("item 6 is "+unlockItem6);
        if(unlockItem6)
        {
            resetItemStatus();
            item6 = true;
            changeItem();
        }
        else if(!unlockItem6 && PlayerPrefs.GetInt("currencyStored") >= 3)
        {
            int subsCoins = PlayerPrefs.GetInt("currencyStored") - 3;
            PlayerPrefs.SetInt("currencyStored", subsCoins);
            unlockItem6 =true;
            PlayerPrefs.SetInt("unlockItem6",unlockItem6?1:0);
            resetItemStatus();
            item6 = true;
            changeItem();
        }
        else
        {
            Debug.Log("Uangnya tidak cukup bos!");
        }
    }

    public void equipItem_7()
    {
        Debug.Log("item 7 is "+unlockItem7);
        if(unlockItem7)
        {
            resetItemStatus();
            item7 = true;
            changeItem();
        }
        else if(!unlockItem7 && PlayerPrefs.GetInt("currencyStored") >= 3)
        {
            int subsCoins = PlayerPrefs.GetInt("currencyStored") - 3;
            PlayerPrefs.SetInt("currencyStored", subsCoins);
            unlockItem7 =true;
            PlayerPrefs.SetInt("unlockItem7",unlockItem7?1:0);
            resetItemStatus();
            item7 = true;
            changeItem();
        }
        else
        {
            Debug.Log("Uangnya tidak cukup bos!");
        }
    }
}
