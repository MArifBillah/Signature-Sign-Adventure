using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class currencyTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI storeCoins;
    int currencyStored;
    // Update is called once per frame
    void Update()
    {
        currencyStored = PlayerPrefs.GetInt("currencyStored");
        storeCoins.text = currencyStored.ToString();
    }
}
