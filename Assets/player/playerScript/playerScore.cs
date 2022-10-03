using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI enemyDestroyed;
    public TextMeshProUGUI coinCollection;
    public TextMeshProUGUI coinCollectedInThisSession;
    public int enemyDestroyedCount;
    // this variable is still being used, its just not displayed in the UI
    public int coinCollected;

    // Update is called once per frame
    void Update()
    {
        playerDatas data = saveSystem.LoadPlayer();
        enemyDestroyed.text = enemyDestroyedCount.ToString();
        coinCollection.text = data.totalCurrency.ToString();
        coinCollectedInThisSession.text = coinCollected.ToString();
    }

    public void enemyCount(int add)
    {
        enemyDestroyedCount += add;
    }
}
