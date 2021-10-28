using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options_File : MonoBehaviour
{
    [SerializeField] public static float Music_Volume = 100;
    [SerializeField] public static float SFX_Volume = 100;
    [SerializeField] public Slider Music_Slider;
    [SerializeField] public Slider SFX_Slider;
    [SerializeField] public float musicValue;
    [SerializeField] public float sfxValue;

    public void Update()
    {
        sfxValue = Options_File.SFX_Volume;
        musicValue = Options_File.Music_Volume;
    }

    public void OpeningSettings()
    {
        SFX_Slider.value = Options_File.SFX_Volume;
        Music_Slider.value = Options_File.Music_Volume;
    }

    public void ClosingSettings()
    {
        Options_File.SFX_Volume = SFX_Slider.value;
        Options_File.Music_Volume = Music_Slider.value;
    }

}
