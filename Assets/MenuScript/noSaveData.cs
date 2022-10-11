using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noSaveData : MonoBehaviour
{
    public GameObject menu;
    public GameObject noSaveDataFound;

    public void noData()
    {
        if(!PlayerPrefs.HasKey("LevelSaved"))
        {
            menu.SetActive(false);
            noSaveDataFound.SetActive(true);
        }
    }
}
