using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI enemyDestroyed;
    public int enemyDestroyedCount;

    // Update is called once per frame
    void Update()
    {
        enemyDestroyed.text = enemyDestroyedCount.ToString();
    }

    public void enemyCount(int add)
    {
        enemyDestroyedCount += add;
    }
}
