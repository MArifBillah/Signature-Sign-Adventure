using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI enemyDestroyed;
    public TextMeshProUGUI coinCollection;
    public int enemyDestroyedCount;
    public int coinCollected;

    // Update is called once per frame
    void Update()
    {
        enemyDestroyed.text = enemyDestroyedCount.ToString();
        coinCollection.text = coinCollected.ToString();
    }

    public void enemyCount(int add)
    {
        enemyDestroyedCount += add;
    }
}
