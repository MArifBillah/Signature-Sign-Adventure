using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class accSelector : MonoBehaviour
{

    // public GameObject lock_item1;
    public AudioSource notEnough;
    public GameObject lock_item2;
    public GameObject lock_item3;
    public GameObject lock_item4;
    public GameObject lock_item5;
    public GameObject lock_item6;
    public GameObject lock_item7;

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
        checkingTheItems();
    }
    public void checkingTheItems()
    {
        
        
        item1 = PlayerPrefs.GetInt("Item1")==1?true:false;
        item2 = PlayerPrefs.GetInt("Item2")==1?true:false;
        item3 = PlayerPrefs.GetInt("Item3")==1?true:false;
        item4 = PlayerPrefs.GetInt("Item4")==1?true:false;
        item5 = PlayerPrefs.GetInt("Item5")==1?true:false;
        item6 = PlayerPrefs.GetInt("Item6")==1?true:false;
        item7 = PlayerPrefs.GetInt("Item7")==1?true:false;
        

        changeItem();
        if(PlayerPrefs.HasKey("unlockItem1"))
        {
            unlockItem1 = PlayerPrefs.GetInt("unlockItem1")==1?true:false;
        }else
        {
            unlockItem1 = false;
        }
        
        if(PlayerPrefs.HasKey("unlockItem2"))
        {
            unlockItem2 = PlayerPrefs.GetInt("unlockItem2")==1?true:false;
        }
        else
        {
            unlockItem2 = false;
        }

        if(PlayerPrefs.HasKey("unlockItem3"))
        {
            unlockItem3 = PlayerPrefs.GetInt("unlockItem3")==1?true:false;
        }
        else
        {
            unlockItem3 = false;
        }

        if(PlayerPrefs.HasKey("unlockItem4"))
        {
            unlockItem4 = PlayerPrefs.GetInt("unlockItem4")==1?true:false;
        }
        else
        {
            unlockItem4 = false;
        }

        if(PlayerPrefs.HasKey("unlockItem5"))
        {
            unlockItem5 = PlayerPrefs.GetInt("unlockItem5")==1?true:false;
        }
        else
        {
            unlockItem5 = false;
        }
        
        if(PlayerPrefs.HasKey("unlockItem6"))
        {
            unlockItem6 = PlayerPrefs.GetInt("unlockItem6")==1?true:false;
        }
        else
        {
            unlockItem6 = false;
        }

        if(PlayerPrefs.HasKey("unlockItem7"))
        {
            unlockItem7 = PlayerPrefs.GetInt("unlockItem7")==1?true:false;
        }
        else
        {
            unlockItem7 = false;
        }

        string activeScene = SceneManager.GetActiveScene().name;
        if(activeScene =="mainMenu")
        {
            deleteLock();
        }
        // unlockItem2 = PlayerPrefs.GetInt("unlockItem2")==1?true:false;
        // unlockItem3 = PlayerPrefs.GetInt("unlockItem3")==1?true:false;
        // unlockItem4 = PlayerPrefs.GetInt("unlockItem4")==1?true:false;
        // unlockItem5 = PlayerPrefs.GetInt("unlockItem5")==1?true:false;
        // unlockItem6 = PlayerPrefs.GetInt("unlockItem6")==1?true:false;
        // unlockItem7 = PlayerPrefs.GetInt("unlockItem7")==1?true:false;
    }

    void Update()
    {
        // Debug.Log(unlockItem2);
    }

    public void deleteLock()
    {
        Debug.Log("this shouldnt be accessed"); 
        if(unlockItem2)
        {
            lock_item2.SetActive(false);
        }
        else if(!unlockItem2)
        {
            lock_item2.SetActive(true);
        }

        if(unlockItem3)
        {
            lock_item3.SetActive(false);
        }
        else if(!unlockItem3)
        {
            lock_item3.SetActive(true);
        }

        if(unlockItem4)
        {
            lock_item4.SetActive(false);
        }
        else if(!unlockItem4)
        {
            lock_item4.SetActive(true);
        }

        if(unlockItem5)
        {
            lock_item5.SetActive(false);
        }
        else if(!unlockItem5)
        {
            lock_item5.SetActive(true);
        }

        if(unlockItem6)
        {
            lock_item6.SetActive(false);
        }
        else if(!unlockItem6)
        {
            lock_item6.SetActive(true);
        }

        if(unlockItem7)
        {
            lock_item7.SetActive(false);
        }
        else if(!unlockItem7)
        {
            lock_item7.SetActive(true);
        }
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

        string activeScene = SceneManager.GetActiveScene().name;
        if(activeScene =="mainMenu")
        {
            deleteLock();
        }
        if(item1)
        {
            if(!item_1.activeSelf)
            {
                item_1.SetActive(true);
            }
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
        else if(!unlockItem2 && PlayerPrefs.GetInt("currencyStored") >= 20)
        {
            int subsCoins = PlayerPrefs.GetInt("currencyStored") - 20;
            PlayerPrefs.SetInt("currencyStored", subsCoins);
            unlockItem2 =true;
            PlayerPrefs.SetInt("unlockItem2",unlockItem2?1:0);
            resetItemStatus();
            item2 = true;
            changeItem();
        }
        else
        {
            notEnough.Play();
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
        else if(!unlockItem3 && PlayerPrefs.GetInt("currencyStored") >= 50)
        {
            int subsCoins = PlayerPrefs.GetInt("currencyStored") - 50;
            PlayerPrefs.SetInt("currencyStored", subsCoins);
            unlockItem3 =true;
            PlayerPrefs.SetInt("unlockItem3",unlockItem3?1:0);
            resetItemStatus();
            item3 = true;
            changeItem();
        }
        else
        {
            notEnough.Play();
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
        else if(!unlockItem4 && PlayerPrefs.GetInt("currencyStored") >= 150)
        {
            int subsCoins = PlayerPrefs.GetInt("currencyStored") - 150;
            PlayerPrefs.SetInt("currencyStored", subsCoins);
            unlockItem4 =true;
            PlayerPrefs.SetInt("unlockItem4",unlockItem4?1:0);
            resetItemStatus();
            item4 = true;
            changeItem();
        }
        else
        {
            notEnough.Play();
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
        else if(!unlockItem5 && PlayerPrefs.GetInt("currencyStored") >= 250)
        {
            int subsCoins = PlayerPrefs.GetInt("currencyStored") - 250;
            PlayerPrefs.SetInt("currencyStored", subsCoins);
            unlockItem5 =true;
            PlayerPrefs.SetInt("unlockItem5",unlockItem5?1:0);
            resetItemStatus();
            item5 = true;
            changeItem();
        }
        else
        {
            notEnough.Play();
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
        else if(!unlockItem6 && PlayerPrefs.GetInt("currencyStored") >= 400)
        {
            int subsCoins = PlayerPrefs.GetInt("currencyStored") - 400;
            PlayerPrefs.SetInt("currencyStored", subsCoins);
            unlockItem6 =true;
            PlayerPrefs.SetInt("unlockItem6",unlockItem6?1:0);
            resetItemStatus();
            item6 = true;
            changeItem();
        }
        else
        {
            notEnough.Play();
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
        else if(!unlockItem7 && PlayerPrefs.GetInt("currencyStored") >= 3000)
        {
            int subsCoins = PlayerPrefs.GetInt("currencyStored") - 3000;
            PlayerPrefs.SetInt("currencyStored", subsCoins);
            unlockItem7 =true;
            PlayerPrefs.SetInt("unlockItem7",unlockItem7?1:0);
            resetItemStatus();
            item7 = true;
            changeItem();
        }
        else
        {
            notEnough.Play();
            Debug.Log("Uangnya tidak cukup bos!");
        }
    }
}
