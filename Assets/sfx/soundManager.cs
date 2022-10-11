using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManager : MonoBehaviour
{
    public Slider soundSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("gameVolume"))
        {
            PlayerPrefs.SetFloat("gameVolume", 1);
            load();
        }else
        {
            load();
        }
    }

    public void changeVolume()
    {
        AudioListener.volume = soundSlider.value;
        save();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void load()
    {
        soundSlider.value = PlayerPrefs.GetFloat("gameVolume");
    }

    void save()
    {
        PlayerPrefs.SetFloat("gameVolume", soundSlider.value);
    }
}
