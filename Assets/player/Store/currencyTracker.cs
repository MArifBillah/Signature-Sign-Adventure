using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class currencyTracker : MonoBehaviour
{
    // Start is called before the first frame update
    int currency;
    public TextMeshProUGUI storeCoins;
    void Start()
    {
        playerDatas data = saveSystem.LoadPlayer();
        currency = data.totalCurrency;
    }

    // Update is called once per frame
    void Update()
    {
        storeCoins.text = currency.ToString();
    }
}
