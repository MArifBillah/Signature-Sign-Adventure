using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTexture : MonoBehaviour
{
    //Set these Textures in the Inspector
    Texture m_MainTexture;
    public Texture A;
    public Texture B;
    public Texture C;
    int randomNumber;
    bool choice = false;
    KeyCode jawab;
    
    Renderer m_Renderer;

    // Use this for initialization
    public void showTexture () {
        choice = true;
        randomNumber = Random.Range(1, 3);
        //Fetch the Renderer from the GameObject
        m_Renderer = GetComponent<Renderer> ();
        switch (randomNumber)
        {
            case 1:
                m_MainTexture = A;
                jawab = KeyCode.A;
                break;
            case 2:
                m_MainTexture = B;
                jawab = KeyCode.B;
                break;
            case 3:
                m_MainTexture = C;
                jawab = KeyCode.C;
                break;
            default:
                Debug.Log("Seharusnya ini gak di print");
                break;
        }
        //Set the Texture you assign in the Inspector as the main texture (Or Albedo)
        m_Renderer.material.SetTexture("_MainTex", m_MainTexture);

    }

    // Update is called once per frame
    void Update()
    {
        if(choice)
        {
            if(Input.GetKeyDown(jawab))
            {
                
                Debug.Log("jawaban benar");
                GameObject.Find("powerBoost").GetComponent<powerBoostMachine>().cancelBooster();
                // choice = false;
            }
        }
        
    }
}
