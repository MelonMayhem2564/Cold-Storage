using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System;
using Unity.VisualScripting.FullSerializer;
using TMPro;
using UnityEngine.Audio;

public class Playerprefs : MonoBehaviour
{
    public Slider Musicvolume;
    public Slider Soundeffectsvolume;
    public Toggle Musictoggle;
    public Toggle Soundeffectstoggle;

    public void Start()
    {
        print("playerprefs start");
        if (PlayerPrefs.HasKey("musicVol") == true)
        {
            Musicvolume.value = PlayerPrefs.GetFloat("musicVol");
            print("Getting musicvol from playerprefs " + Musicvolume.value);
        }
        else
        {
            Musicvolume.value = 0.5f;
        }

        if (PlayerPrefs.HasKey("musicToggle") == true)
        {
            int toggle = PlayerPrefs.GetInt("musicToggle");

            if (toggle == 0)
            {
                Musictoggle.isOn = false;
            }
            else
            {
                Musictoggle.isOn = true;
            }
        }
        else
        {
            Musictoggle.isOn = true; // set button tick box to ON
            PlayerPrefs.SetInt("musicToggle", 1);
        }


        if (PlayerPrefs.HasKey("soundEffectsVol") == true)
        {
            Soundeffectsvolume.value = PlayerPrefs.GetFloat("soundEffectsVol");
            print("Getting soundeffectsvol from playerprefs " + Soundeffectsvolume.value);
        }
        else
        {
            Soundeffectsvolume.value = 0.5f;
        }
    }

    public void MusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("musicVol", volume);
        print("setting slider to " + volume);
    }
    public void SoundEffectsVolume(float volume)
    {
        PlayerPrefs.SetFloat("soundEffectsVol", volume);
    }
    public void MusicToggle(bool music)
    {
        PlayerPrefs.SetInt("musicToggle", music ? 1 : 0);
        print("music set to " + music);
    }
    
    public void MusicVolumeChanged(float vol)
    {
        print("The music volume is now " + vol);
        MusicVolume(vol);
    }
    public void SoundEffectsVolumeChanged(float vol)
    {
        print("The sound effects volume is now " + vol);
        SoundEffectsVolume(vol);
    }
    public void MusicToggleChanged(int mus)
    {
        print("The music is now " + mus);
    }
}
