using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageHit : MonoBehaviour
{
    // Start is called before the first frame update
    public int bulletDamage;
    // private int enemyBulletDamage = 20;
    void Start()
    {
    //  Destroy(gameObject, 10);   
    }


    void Update()
    {
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        // Destroy(transform.GetComponent<Rigidbody>());
        // Debug.Log("hello hello on trigger");
        if(other.tag == "enemy")
        {
            other.GetComponent<enemy>().TakeDamage(bulletDamage);
        }
        else if(other.tag == "Player")
        {
            // Debug.Log("player kena damage");
            other.GetComponent<playerHealth>().PlayerDamage(10);
            GameObject.FindWithTag("enemy").GetComponent<enemy>().destroyEnemyBullet();
        }

        GameObject.Find("gun").GetComponent<shootingGun>().destroyBullet();
        
       
    }
}
