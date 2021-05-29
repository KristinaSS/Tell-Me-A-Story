using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void DropdownItemSelected(Dropdown dropdown)
    {
        switch (dropdown.options[dropdown.value].text)
        {
            case "English":
                Debug.Log("EN");
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0]; 
                break;
            case "Български":
                Debug.Log("BG");
                LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1]; 
                break;
        }
    }
}